using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;
using NUnit.Framework;
using System.Windows.Forms;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Eng_Flash_Cards_Learner.NOT_Forms
{
    public class DB_SQLite
    {
        //TODO - remove "public"
        public SQLiteConnection connection; // = new SQLiteConnection("Data Source=.\\Vocabulary.db;Version=3;");

        public DB_SQLite(string connectionInfo)
        {
            connection = new SQLiteConnection(connectionInfo);
            OpenConnection();
        }


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


        //TESTED ✔️
        #region [Категорії слів]

        #region Певну кількість слів (або всіх) певної категорії

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


        #region Отримати / Змінити поточну категорію для додавання слів

        public int Get_CurrentCategory()
        {
            var reader = Get_DataReader("SELECT CurrentCategoryID FROM Settings;");
            reader.Read();
            return reader.GetInt32(0);
        }

        public void Set_CurrentCategory(int currentCategoryID)
            => Get_DataReader($"UPDATE Settings SET CurrentCategoryID = {currentCategoryID} WHERE SettingsID = 1;");
        #endregion


        #region Отримати інформацію про Категорії / Додавання нової 

        /// <summary>
        /// Отрмати список категорій з БД де Count = number
        /// </summary>
        /// <returns>Список значень типу DB_WordCategory з інформацією про категорію</returns>
        public List<DB_WordCategory> Get_Categories()
        {
            string query = $"SELECT * FROM Categories ORDER BY CategoryID";
            var reader = Get_DataReader(query);
            var categories = new List<DB_WordCategory>();

            while (reader.Read())
                categories.Add(new DB_WordCategory
                {
                    CategoryID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    CreatedAt = DateTime.Parse(reader.GetString(2)),
                    CanBeDeleted = reader.GetInt32(3) == 1,
                    IsDeleted = reader.GetInt32(4) == 1,
                    DeletedAt = DateTime.Parse(reader.GetString(5)),
                });
            return categories;
        }

        bool Is_CategoryRepeated(string categoryName)
            => Get_DataReader($"SELECT * FROM Categories WHERE Name = '{categoryName}';").HasRows;

        public bool Add_NewCategory(string categoryName)
        {
            if (Is_CategoryRepeated(categoryName)) return false;

            Get_DataReader($"INSERT INTO Categories (Name, Deleted, CanBeDeleted) VALUES ('{categoryName}', 0, 1);");
            return true;
        }
        #endregion
        

        #region Видалення категорії (корзина / повне) / Відновлення 

        /// <summary>
        /// Позначає категорію в 'Categories' як видалена й додає час (позначення) виделення в "DeletedAt"
        /// </summary>
        /// <param name="categoryID">'CategoryID' категорії яка (позначатиметься як) видалена</param>
        /// <returns>Значення true якщо (позначення як) видалення пройшло успішно</returns>
        public bool TryMarkAsRemoved_Category(int categoryID)
        {
            bool categoryCanBeDeleted = Convert.ToInt32(
                (new SQLiteCommand($"SELECT CanBeDeleted FROM Categories WHERE CategoryID = {categoryID}", connection)).ExecuteScalar()) == 1;
            if (!categoryCanBeDeleted) return false;

            int currentCategoryID = Convert.ToInt32((new SQLiteCommand("SELECT CurrentCategoryID FROM Settings", connection)).ExecuteScalar());
            if (currentCategoryID == categoryID)
                Get_DataReader("UPDATE Settings SET CurrentCategoryID = 1 WHERE SettingsID = 1;");

            Get_DataReader($"UPDATE Categories SET Deleted = 1, DeletedAt = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}' WHERE CategoryID = {categoryID};");
            return true;
        }

        /// <summary>
        /// Повністю видаляє категорії які знахдяться "корзині" більше ніж певну кількість днів
        /// </summary>
        /// <param name="retentionDayCountInRecycleBin">Кількість днів протягом якої категорія може зберігатися в "корзині"</param>
        public void FindAndRemove_LongMarkedCategories(int retentionDayCountInRecycleBin = 7)
        {
            TimeSpan retentionTimeInRecycleBin = TimeSpan.FromDays(retentionDayCountInRecycleBin);
            var categoriesInfoToBeDeleted = Get_Categories()
                .Where(x => x.IsDeleted && ((DateTime.Now - x.DeletedAt) > retentionTimeInRecycleBin))
                .ToList();

            foreach (var category in categoriesInfoToBeDeleted)
            {
                //Видалення всіх слів з WordCategories пов'язаних з категорією, яку видаляємо
                Get_DataReader($"DELETE FROM WordCategories WHERE CategoryID = {category.CategoryID};");
                //Видалення самої категорії з Categories
                Get_DataReader($"DELETE FROM Categories WHERE CategoryID = {category.CategoryID};");
            }
        }

        public void Restore_Category_FromDeletion(int categoryID)
        {
            //Відновлення "нормальних" значень полів категорії в 'Categories'
            Get_DataReader($"UPDATE Categories SET Deleted = 0 WHERE CategoryID = {categoryID};");
        }
        #endregion


        #region Додати слово(слова) в категорію / Скасувати його(їх) додавання / Видалити з категорії

        bool Is_WordRepeated_InCategory(int wordID, int categoryID)
            => Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = '{wordID}' AND CategoryID = '{categoryID}';").HasRows;

        public bool TryAdd_Word_ToCategory(int wordID, int categoryID)
        {
            if (wordID < 1 || categoryID < 1) 
                throw new ArgumentException("wordID and categoryID arguments can't be less than '1'");
            if (Is_WordRepeated_InCategory(wordID, categoryID)) return false;

            Get_DataReader($"INSERT INTO WordCategories (WordID, CategoryID) VALUES ({wordID}, {categoryID});");
            return true;
        }

        public void Remove_LastWord_FromCategory(int count)
            => Get_DataReader($"DELETE FROM WordCategories ORDER BY AddedAt DESC LIMIT {count};");

        public void Remove_Word_FromCategory(int wordID, int categoryID)
        {
            if (categoryID != 1)
                Get_DataReader($"DELETE FROM WordCategories WHERE WordID = {wordID} AND CategoryID = {categoryID};");
        }

        #endregion

        #endregion


        //TESTED ✔️
        #region Додати слово в БД / Скасувати його(їх) додавання / Видалити з БД

        bool WordIsRepeated_InAllWords(string engW)
            => Get_DataReader($"SELECT * FROM AllWords WHERE EngWord = '{engW}';").HasRows;

        public bool TryAdd_Word_ToAllWords(string engW, string uaW, int categoryID = 1)
        {
            if (WordIsRepeated_InAllWords(engW)) return false;

            uaW = uaW.Replace("'", "''");
            var reader = Get_DataReader("INSERT INTO AllWords (EngWord, UaTranslation, Rating, Repetition) " +
                $"VALUES ('{engW}', '{uaW}', 0, 0); SELECT last_insert_rowid();");
            reader.Read();
            int wordID = reader.GetInt32(0);

            //Додавання до основної категорії, після - до додаткової
            if (!TryAdd_Word_ToCategory(wordID, 1)) throw new Exception("Чогось не хоче додаватися до категорій слів!");
            return categoryID == 1 || TryAdd_Word_ToCategory(wordID, categoryID);
        }

        public void Remove_LastWords_Permanently(int count)
        {
            List<int> wordIDsForRemoving = new();

            var reader = Get_DataReader($"SELECT WordID FROM WordCategories ORDER BY WordID DESC, AddedAt DESC LIMIT {count};"); //Можна замінити WordID на AddedAt
            while (reader.Read())
                wordIDsForRemoving.Add(reader.GetInt32(0));

            for (int i = 0; i < wordIDsForRemoving.Count; i++)
                Remove_Word_Permanently(wordIDsForRemoving[i]);
        }

        public void Remove_Word_Permanently(int wordID)
        {
            Get_DataReader($"DELETE FROM WordCategories WHERE WordID = {wordID}");
            Get_DataReader($"DELETE FROM AllWords WHERE WordID = {wordID}");
        }
        #endregion


        //TEST
        #region Отримати слова

        /// <summary>
        /// Отрмати список слів з БД де Count = number
        /// </summary>
        /// <param name="number">Кількість слів для вивчення</param>
        /// <returns>Список слів </returns>
        public List<DB_Word> GetWords(int number)
        {
            string query = $"SELECT * FROM AllWords ORDER BY Rating LIMIT {number};";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            var reader = Get_DataReader(query);
            var words = new List<DB_Word>();

            while (reader.Read())
                words.Add(new DB_Word 
                { 
                    WordID = reader.GetInt32(0),
                    EngWord = reader.GetString(1),
                    UaTranslation = reader.GetString(2),
                    Rating = reader.GetInt32(3),
                });
            return words;
        }
        #endregion


        //TEST
        #region Оцінювати слово

        public void RateWord(int id, int number)
        {
            string query = $"UPDATE AllWords SET Rating = {number} WHERE WordID = {id};";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            Get_DataReader(query);
        }
        #endregion


        #region Отримати статистику по ВСІХ словах
        public DB_Statistic GetStatistic()
        {
            DB_Statistic stat = new();

            SQLiteCommand cmd = new("SELECT count (*) FROM Words;", connection);
            stat.AllWordCount = Convert.ToInt32(cmd.ExecuteScalar());

            string query;
            for (int i = 0; i <= 5; i++)
            {
                query = $"SELECT count (*) FROM AllWords WHERE Rating = {i};";
                cmd = new SQLiteCommand(query, connection);
                stat.AllRatings[i] = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return stat;
        }
        #endregion


        #region Отримати / Змінити кількість слів для вивчення (за раз)

        public int GetWordsToLearnCount()
        {
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
            string query = $"UPDATE Settings SET WasLaunched = { (wasLaunched ? 1 : 0) } WHERE SettingsID = 1;";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            Get_DataReader(query);
        }
        #endregion

    }
}
