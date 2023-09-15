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
        /*
        public SQLiteConnection connection; // = new SQLiteConnection("Data Source=.\\Vocabulary.db;Version=3;");

        public DB_SQLite(string connectionInfo)
        {
            connection = new SQLiteConnection(connectionInfo);
            OpenConnection();
        }
        */
        /*
        #region Відкрити / Закрити / Отримати з'єднання

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public SQLiteConnection GetConnection()
            => connection;
        #endregion
        */
        /*
        //*********************************************************************************************************
        //TODO - remove "public"
        /// <summary>
        /// Виконує SQL-команду й повертає DataReader
        /// </summary>
        /// <param name="query">SQL-команда</param>
        /// <returns>Значення типу SQLiteDataReader</returns>
        public SQLiteDataReader Get_DataReader(string query)
        {
            SQLiteCommand cmd = new(query, connection);
            return cmd.ExecuteReader();
        }
        //*********************************************************************************************************
        */

        //TEST-TEST
        #region [Категорії слів]

        //RESOLVE
        #region Отримати певну кількість слів (або всіх) певної категорії

        /// <summary>
        /// Отрмати список слів (DB_Word) з певної категорії й певну кількість
        /// </summary>
        /// <param name="categoryID">ID категорії</param>
        /// <param name="wordCount">Кількість слів для виводу</param>
        /// <returns>Список слів (DB_Word)</returns>
        public List<DB_Word> Get_Words_FromCategory(int categoryID, int wordCount = -1)
        {
            string query = "SELECT AllWords.WordID, AllWords.EngWord, AllWords.UaTranslation, " +
                "AllWords.Rating, AllWords.Repetition, WordCategories.AddedAt " +
                "FROM AllWords JOIN WordCategories ON AllWords.WordID = WordCategories.WordID " +
                $"WHERE WordCategories.CategoryID = {categoryID} ORDER BY AllWords.Rating, WordCategories.AddedAt ";
            if (wordCount < -1)
                throw new ArgumentException("Wrong wordCount number");
            else if (wordCount != -1)
                query += $"LIMIT {wordCount}";

            var reader = Get_DataReader(query);
            var categories = new List<DB_Word>();

            while (reader.Read())
                categories.Add(new DB_Word
                {
                    WordID = reader.GetInt32(0),
                    EngWord = reader.GetString(1),
                    UaTranslation = reader.GetString(2),
                    Rating = reader.GetInt32(3),
                    Repetition = reader.GetInt32(4),
                    AddedAt = DateTime.Parse(reader.GetString(5))
                });
            return categories;
        }

        #endregion

        //TEST
        #region Отримати / Змінити поточну категорію для додавання слів

        public static long Get_CurrentCategory()
        {
            using (VocabularyContext db = new())
                return db.Settings.ToList()[0].CurrentCategoryId;
        }

        public static void Set_CurrentCategory(int currentCategoryID)
        {
            if (currentCategoryID < 1)
                throw new ArgumentException("categoryID arguments can't be less than '1'");

            using VocabularyContext db = new();
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
            using VocabularyContext db = new();
            return db.Categories.ToList();
        }
        static bool Is_CategoryRepeated(string categoryName)
        {
            using VocabularyContext db = new();
            return db.Categories.Any(c => c.Name == categoryName);
        }

        public static bool Add_NewCategory(string categoryName)
        {
            if (Is_CategoryRepeated(categoryName)) return false;

            using VocabularyContext db = new();
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

            using VocabularyContext db = new();

            var category = db.Categories.First(c => c.CategoryId == categoryID);
            var setting = db.Settings.First();

            if (category.CanBeDeleted == false) return false;
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
            using VocabularyContext db = new();

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
            using VocabularyContext db = new();
            db.Categories.First(c => c.CategoryId == categoryID).Deleted = false;
            db.SaveChanges();
        }
        #endregion

        //TEST
        #region Додати слово(слова) в категорію / Скасувати його(їх) додавання / Видалити з категорії

        static bool Is_WordRepeated_InCategory(int wordID, int categoryID)
        {
            using VocabularyContext db = new();
            return db.WordCategories.Any(c => c.WordId == wordID && c.CategoryId == categoryID);
        }

        public static bool TryAdd_Word_ToCategory(int wordID, int categoryID)
        {
            if (wordID < 1 || categoryID < 1)
                throw new ArgumentException("wordID and categoryID arguments can't be less than '1'");
            if (Is_WordRepeated_InCategory(wordID, categoryID)) return false;

            using VocabularyContext db = new();
            db.WordCategories.Add(new WordCategory { CategoryId = categoryID, WordId = wordID });
            db.SaveChanges();
            return true;
        }

        public static void Remove_LastWords_FromCategory(int count)
        {
            using VocabularyContext db = new();
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

            using VocabularyContext db = new();
            db.WordCategories.Remove(db.WordCategories.First(w => w.WordId == wordID && w.CategoryId == categoryID));
            db.SaveChanges();
        }

        #endregion

        #endregion


        //TEST
        #region Додати слово в БД / Скасувати його(їх) додавання / Видалити з БД

        static bool WordIsRepeated_InAllWords(string engW)
        {
            using VocabularyContext db = new();
            return db.AllWords.Any(c => c.EngWord == engW);
        }

        public static bool TryAdd_Word_ToAllWords(string engW, string uaW, int categoryID = 1)
        {
            if (WordIsRepeated_InAllWords(engW)) return false;
            uaW = uaW.Replace("'", "''");

            using VocabularyContext db = new();
            db.AllWords.Add(new Word { EngWord = engW, UaTranslation = uaW });
            db.SaveChanges();

            int wordID = db.AllWords.Last().WordId;
            //Додавання до основної категорії, після (якщо треба) - до додаткової
            if (!TryAdd_Word_ToCategory(wordID, 1)) 
                throw new Exception("Чомусь нове слово не хоче додаватися до категорій слів!");
            return categoryID == 1 || TryAdd_Word_ToCategory(wordID, categoryID);
        }

        public static void Remove_LastWords_Permanently(int count)
        {
            using VocabularyContext db = new();
            //Видалення останніх count слів
            for (int i = 0; i < count; i++)
                Remove_Word_Permanently(db.AllWords.Last().WordId);
            db.SaveChanges();
        }

        public static void Remove_Word_Permanently(int wordID)
        {
            using VocabularyContext db = new();
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
            using VocabularyContext db = new();
            return db.AllWords.OrderBy(w => w.Rating).Take(number).ToList();
        }
        #endregion

        //TEST
        #region Оцінювати слово

        public static void RateWord(int wordId, int rating)
        {
            using VocabularyContext db = new();
            db.AllWords.First(w => w.WordId == wordId).Rating = rating;
            db.SaveChanges();
        }
        #endregion

        //TEST
        #region Отримати статистику по ВСІХ словах
        public static Statistic GetStatistic()
        {
            using VocabularyContext db = new();

            var stat = new int[7];
            for (int i = 0; i <= 5; i++)
                stat[i] = db.AllWords.Where(w => w.Rating == i).Count();
            stat[6] = db.AllWords.Count();

            return new Statistic(stat);
        }
        #endregion


        //RESOLVE
        #region Отримати / Змінити кількість слів для вивчення (за раз)

        public static int GetWordsToLearnCount()
        {
            using VocabularyContext db = new();


            string query = $"SELECT WordCountToLearn FROM Settings;";
            SQLiteCommand cmd = new(query, connection);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        //TEST
        public void SetWordsToLearnCount(int count)
        {
            string query = $"UPDATE Settings SET WordCountToLearn = {count} WHERE SettingsID = 1;";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            Get_DataReader(query);
        }
        #endregion


        //RESOLVE
        #region Отримати / Змінити мод (спосіб) додавання слів

        public int GetWordAddingMode()
        {
            string query = $"SELECT WordAddingMode FROM Settings;";
            SQLiteCommand cmd = new(query, connection);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        //TEST
        public void SetWordAddingMode(int mode)
        {
            string query = $"UPDATE Settings SET WordAddingMode = {mode} WHERE SettingsID = 1;";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            Get_DataReader(query);
        }
        #endregion


        //RESOLVE
        #region Отримати / Змінити значення повторюваності слова

        public int GetWordRepetition(int id)
        {
            string query = $"SELECT Repetition FROM AllWords WHERE WordID = {id};";
            SQLiteCommand cmd = new(query, connection);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void IncrementWordRepetition(int id)
        {
            int wordRepetition = GetWordRepetition(id);
            string query = $"UPDATE AllWords SET Repetition = {++wordRepetition} WHERE WordID = {id};";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            Get_DataReader(query);
        }
        #endregion


        //RESOLVE
        #region Отримати дані чи запускався цей додаток до цього, чи ні

        //TEST
        /// <summary>
        /// Показує чи поле "WasLaunched" має значення "1"
        /// </summary>
        /// <returns></returns>
        public bool WasLaunched()
        {
            string query = $"SELECT * FROM Settings;";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            var reader = Get_DataReader(query);
            reader.Read();

            return reader.GetInt32(2) == 1;
        }

        //TEST
        /// <summary>
        /// Змінює значення "WasLaunched" в таблиці "Settings" в БД
        /// </summary>
        /// <param name="wasLaunched">Значення поля "WasLaunched"</param>
        public void SetWasLaunched(bool wasLaunched)
        {
            string query = $"UPDATE Settings SET WasLaunched = {(wasLaunched ? 1 : 0)} WHERE SettingsID = 1;";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            Get_DataReader(query);
        }
        #endregion
    }
}
