using Eng_Flash_Cards_Learner.NOT_Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Eng_Flash_Cards_Learner.EF_SQLite
{
    public static class SQLs
    {
        /// <summary>
        /// Connection String (contains path to .db file)
        /// </summary>
        public static string ConStr { get; set; } = "Data Source=.\\Vocabulary.db;";

        //TEST-TEST
        #region [Категорії слів]

        //TEST
        #region Отримати певну кількість слів (або всіх) певної категорії

        /// <summary>
        /// Отрмати список слів (DB_Word) з певної категорії й певну кількість
        /// </summary>
        /// <param name="categoryID">ID категорії</param>
        /// <param name="wordCount">Кількість слів для виводу</param>
        /// <returns>Список слів (DB_Word)</returns>
        public static List<Tuple<Word, DateTime>> Get_Words_FromCategory(int categoryID, int wordCount = -1)
        {
            using VocabularyContext db = new(ConStr);

            List<Tuple<Word, DateTime>> wordsInfo = new();

            wordsInfo = db.AllWords
                .Join(db.WordCategories,
                    word => word.WordId,
                    wordCategory => wordCategory.WordId,
                    (word, wordCategory) => Tuple.Create(word, wordCategory))
                .Where(result => result.Item2.CategoryId == categoryID)
                .OrderBy(result => result.Item1.Rating)
                .ThenBy(result => result.Item2.AddedAt)
                .Select(w => Tuple.Create(w.Item1, w.Item2.AddedAt))
                .ToList();
            return wordsInfo;
        }

        #endregion

        //TEST
        #region Отримати / Змінити поточну категорію для додавання слів

        public static int Get_CurrentCategory()
        {
            using VocabularyContext db = new(ConStr);
            return db.Settings.ToList()[0].CurrentCategoryId;
        }

        public static void Set_CurrentCategory(int currentCategoryID)
        {
            if (currentCategoryID < 1)
                throw new ArgumentException("categoryID arguments can't be less than '1'");

            using VocabularyContext db = new(ConStr);
            db.Settings.First().CurrentCategoryId = currentCategoryID;
            db.SaveChanges();
        }
        #endregion

        //TEST
        #region Отримати інформацію про Категорії / Додавання нової 

        /// <summary>
        /// Отрмати список категорій з БД де Count = number
        /// </summary>
        /// <returns>Список значень типу DB_WordCategory з інформацією про категорію</returns>
        public static List<Category> Get_Categories()
        {
            using VocabularyContext db = new(ConStr);
            return db.Categories.ToList();
        }

        static bool Is_CategoryRepeated(string categoryName)
        {
            using VocabularyContext db = new(ConStr);
            return db.Categories.Any(c => c.Name == categoryName);
        }

        public static bool Add_NewCategory(string categoryName)
        {
            if (Is_CategoryRepeated(categoryName)) return false;

            using VocabularyContext db = new(ConStr);
            db.Categories.Add(new Category { Name = categoryName });
            db.SaveChanges();

            return true;
        }
        #endregion

        //TEST
        #region Видалення категорії (корзина / повне) / Відновлення 

        /// <summary>
        /// Позначає категорію в 'Categories' як видалена й додає час (позначення) виделення в "DeletedAt"
        /// </summary>
        /// <param name="categoryID">'CategoryID' категорії яка (позначатиметься як) видалена</param>
        /// <returns>Значення true якщо (позначення як) видалення пройшло успішно</returns>
        public static bool TryMarkAsRemoved_Category(int categoryID)
        {
            if (categoryID < 1)
                throw new ArgumentException("categoryID arguments can't be less than '1'");

            using VocabularyContext db = new(ConStr);

            var category = db.Categories.First(c => c.CategoryId == categoryID);
            var setting = db.Settings.First();

            if (!category.CanBeDeleted) return false;
            if (setting.CurrentCategoryId == categoryID)
                setting.CurrentCategoryId = 1;

            category.Deleted = true;
            category.DeletedAt = DateTime.Now;

            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Повністю видаляє категорії які знахдяться "корзині" більше ніж певну кількість днів
        /// </summary>
        /// <param name="retentionDayCountInRecycleBin">Кількість днів протягом якої категорія може зберігатися в "корзині"</param>
        public static void FindAndRemove_LongMarkedCategories(int retentionDayCountInRecycleBin = 7)
        {
            using VocabularyContext db = new(ConStr);

            TimeSpan retentionTimeInRecycleBin = TimeSpan.FromDays(retentionDayCountInRecycleBin);
            var categoriesToBeDeleted = db.Categories
                .Where(c => c.Deleted && ((DateTime.Now - c.DeletedAt) > retentionTimeInRecycleBin))
                .ToList();

            foreach (var category in categoriesToBeDeleted)
                //Видалення всіх слів з WordCategories пов'язаних з категоріями, які видаляємо
                db.WordCategories.RemoveRange(db.WordCategories
                    .Where(c => c.CategoryId == category.CategoryId)
                    .ToList());
                //db.Categories.Remove(db.Categories.Where(c => c.CategoryId == category.CategoryId).First());  //REMOVE

            //Видалення самих категорій з Categories
            db.Categories.RemoveRange(categoriesToBeDeleted);
            db.SaveChanges();
        }

        public static void Restore_Category_FromDeletion(int categoryID)
        {
            if (categoryID < 1)
                throw new ArgumentException("categoryID arguments can't be less than '1'");

            //Відновлення "нормальних" значень полів категорії в 'Categories'
            using VocabularyContext db = new(ConStr);
            db.Categories.First(c => c.CategoryId == categoryID).Deleted = false;
            db.SaveChanges();
        }
        #endregion

        //TEST
        #region Додати слово(слова) в категорію / Скасувати його(їх) додавання / Видалити з категорії

        static bool Is_WordRepeated_InCategory(int wordID, int categoryID)
        {
            using VocabularyContext db = new(ConStr);
            return db.WordCategories.Any(c => c.WordId == wordID && c.CategoryId == categoryID);
        }

        public static bool TryAdd_Word_ToCategory(int wordID, int categoryID)
        {
            if (wordID < 1 || categoryID < 1)
                throw new ArgumentException("wordID and categoryID arguments can't be less than '1'");
            if (Is_WordRepeated_InCategory(wordID, categoryID)) return false;

            using VocabularyContext db = new(ConStr);
            db.WordCategories.Add(new WordCategory { CategoryId = categoryID, WordId = wordID });
            db.SaveChanges();
            return true;
        }

        public static void Remove_LastWords_FromCategory(int count)
        {
            using VocabularyContext db = new(ConStr);
            var wordsToBeDeleted = db.WordCategories.OrderBy(w => w.AddedAt).Take(count).ToList();
            db.WordCategories.RemoveRange(wordsToBeDeleted);
            db.SaveChanges();
        }

        public static void Remove_Word_FromCategory(int wordID, int categoryID)
        {
            if (wordID < 1 || categoryID < 1)
                throw new ArgumentException("wordID and categoryID arguments can't be less than '1'");
            if (categoryID == 1)
                throw new ArgumentException("the main category (#1) can't be deleted");

            using VocabularyContext db = new(ConStr);
            db.WordCategories.Remove(db.WordCategories.First(w => w.WordId == wordID && w.CategoryId == categoryID));
            db.SaveChanges();
        }

        #endregion

        #endregion

        //TEST
        #region Додати слово в БД / Скасувати його(їх) додавання / Видалити з БД

        static bool WordIsRepeated_InAllWords(string engW)
        {
            using VocabularyContext db = new(ConStr);
            return db.AllWords.Any(c => c.EngWord == engW);
        }

        public static bool TryAdd_Word_ToAllWords(string engW, string uaW, int categoryID = 1)
        {
            if (WordIsRepeated_InAllWords(engW)) return false;
            uaW = uaW.Replace("'", "''");

            using VocabularyContext db = new(ConStr);
            db.AllWords.Add(new Word { EngWord = engW, UaTranslation = uaW });
            db.SaveChanges();

            int wordID = db.AllWords.OrderBy(w => w.WordId).Last().WordId;
            //Додавання до основної категорії, після (якщо треба) - до додаткової
            if (!TryAdd_Word_ToCategory(wordID, 1)) 
                throw new Exception("Чомусь нове слово не хоче додаватися до категорій слів!");
            return categoryID == 1 || TryAdd_Word_ToCategory(wordID, categoryID);
        }

        public static void Remove_LastWords_Permanently(int count)
        {
            using VocabularyContext db = new(ConStr);
            //Видалення останніх count слів
            for (int i = 0; i < count; i++)
                Remove_Word_Permanently(db.AllWords.OrderBy(w => w.WordId).Last().WordId);
            db.SaveChanges();
        }

        public static void Remove_Word_Permanently(int wordID)
        {
            using VocabularyContext db = new(ConStr);
            //Видалення слова з усіх категорій
            db.WordCategories.RemoveRange(db.WordCategories.Where(w => w.WordId == wordID).ToList());
            //Видалення слова з AllWords
            db.AllWords.Remove(db.AllWords.First(w => w.WordId == wordID));
            db.SaveChanges();
        }
        #endregion

        //TEST
        #region Отримати слова

        /// <summary>
        /// Отримати список слів з БД де Count = number
        /// </summary>
        /// <param name="number">Кількість слів для вивчення</param>
        /// <returns>Список слів </returns>
        public static List<Word> GetWords(int number)
        {
            using VocabularyContext db = new(ConStr);
            return db.AllWords.OrderBy(w => w.Rating).Take(number).ToList();
        }
        #endregion

        //TEST
        #region Отримати / Змінити значення повторюваності слова

        public static int GetWordRepetition(int wordId)
        {
            using VocabularyContext db = new(ConStr);
            return db.AllWords.First(w => w.WordId == wordId).Repetition;
        }

        public static void IncrementWordRepetition(int wordId)
        {
            using VocabularyContext db = new(ConStr);
            int wordRepetition = db.AllWords.First(w => w.WordId == wordId).Repetition;
            db.AllWords.First().Repetition = ++wordRepetition;
            db.SaveChanges();
        }
        #endregion

        //TEST
        #region Оцінювати слово

        public static void RateWord(int wordId, int rating)
        {
            using VocabularyContext db = new(ConStr);
            db.AllWords.First(w => w.WordId == wordId).Rating = rating;
            db.SaveChanges();
        }
        #endregion

        //************************

        //TEST
        #region Отримати статистику по ВСІХ словах
        public static Statistic GetStatistic()
        {
            using VocabularyContext db = new(ConStr);

            var stat = new int[7];
            for (int i = 0; i <= 5; i++)
                stat[i] = db.AllWords.Where(w => w.Rating == i).Count();
            stat[6] = db.AllWords.Count();

            return new Statistic(stat);
        }
        #endregion

        //TEST
        #region Отримати / Змінити кількість слів для вивчення (за раз)

        public static int GetWordsToLearnCount()
        {
            using VocabularyContext db = new(ConStr);
            return db.Settings.First().WordCountToLearn;
        }

        public static void SetWordsToLearnCount(int count)
        {
            using VocabularyContext db = new(ConStr);
            db.Settings.First().WordCountToLearn = count;
            db.SaveChanges();
        }
        #endregion

        //TEST
        #region Отримати / Змінити мод (спосіб) додавання слів

        public static int GetWordAddingMode()
        {
            using VocabularyContext db = new(ConStr);
            return db.Settings.First().WordAddingMode;
        }

        public static void SetWordAddingMode(int mode)
        {
            using VocabularyContext db = new(ConStr);
            db.Settings.First().WordAddingMode = mode;
            db.SaveChanges();
        }
        #endregion

        //TEST
        #region Отримати дані чи запускався цей додаток до цього, чи ні

        /// <summary>
        /// Показує чи поле "WasLaunched" має значення "1"
        /// </summary>
        /// <returns></returns>
        public static bool WasLaunched()
        {
            using VocabularyContext db = new(ConStr);
            return db.Settings.First().WasLaunched;
        }

        /// <summary>
        /// Змінює значення "WasLaunched" в таблиці "Settings" в БД
        /// </summary>
        /// <param name="wasLaunched">Значення поля "WasLaunched"</param>
        public static void SetWasLaunched(bool wasLaunched)
        {
            using VocabularyContext db = new(ConStr);
            db.Settings.First().WasLaunched = wasLaunched;
            db.SaveChanges();
        }
        #endregion
    }
}
