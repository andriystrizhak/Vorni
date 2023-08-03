using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Eng_Flash_Cards_Learner.Logic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;
using Eng_Flash_Cards_Learner.NOT_Forms;
using NUnit.Framework;
using System.Windows.Forms;

namespace Eng_Flash_Cards_Learner
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
        //TODO - delete "public"
        /// <summary>
        /// Виконує SQL-команду й повертає DataReader
        /// </summary>
        /// <param name="query">SQL-команда</param>
        /// <returns>Значення типу SQLiteDataReader</returns>
        public SQLiteDataReader Get_DataReader(string query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            return cmd.ExecuteReader();
        }
        //*********************************************************************************************************

        //TESTED ✔️
        #region [Категорії слів]

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
                    CreationDate = DateTime.Parse(reader.GetString(2)),
                    IsDeleted = reader.GetInt32(3) == 1,
                    CanBeDeleted = reader.GetInt32(4) == 1,
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

        #region Додати слово(слова) в категорію / Скасувати його(їх) додавання 

        bool Is_WordRepeated_InCategory(int wordID, int categoryID)
            => Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = '{wordID}' AND CategoryID = '{categoryID}';").HasRows;

        public bool TryAdd_Word_ToCategory(int wordID, int categoryID)
        {
            if (Is_WordRepeated_InCategory(wordID, categoryID)) return false;

            Get_DataReader($"INSERT INTO WordCategories (WordID, CategoryID) VALUES ({wordID}, {categoryID});");
            return true;
        }

        public void Remove_LastWord_FromCategory(int count)
            => Get_DataReader($"DELETE FROM WordCategories ORDER BY AddedAt DESC LIMIT {count};");
        #endregion

        #endregion

        //TESTED ✔️
        #region Додати слово в БД / Скасувати його(їх) додавання

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
            return categoryID != 1 ? TryAdd_Word_ToCategory(wordID, categoryID) : true;
        }

        public void Remove_LastWords_FromAllWords(int count)
        {
            List<int> wordIDsForRemoving = new List<int>();

            var reader = Get_DataReader($"SELECT WordID FROM WordCategories ORDER BY WordID DESC, AddedAt DESC LIMIT {count};"); //Можна замінити WordID на AddedAt
            while (reader.Read())
                wordIDsForRemoving.Add(reader.GetInt32(0));

            for (int i = 0; i < wordIDsForRemoving.Count; i++)
            {
                Get_DataReader($"DELETE FROM AllWords WHERE WordID = {wordIDsForRemoving[i]}");
                Get_DataReader($"DELETE FROM WordCategories WHERE WordID = {wordIDsForRemoving[i]}");
            }
            /*
            for (int i = 0; i < count; i++)
            {
                var reader1= GetDataReader($"SELECT WordID FROM WordCategories ORDER BY WordID DESC LIMIT {count};");
                reader1.Read();
                int wordIDForRemoving = reader1.GetInt32(0);
                GetDataReader($"DELETE FROM AllWords WHERE WordID = {wordIDForRemoving}");
                GetDataReader($"DELETE FROM WordCategories WHERE WordID = {wordIDForRemoving}");
            }
            */
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
            DB_Statistic stat = new DB_Statistic();

            SQLiteCommand cmd = new SQLiteCommand("SELECT count (*) FROM Words;", connection);
            stat.allWordCount = Convert.ToInt32(cmd.ExecuteScalar());

            string query;
            for (int i = 0; i <= 5; i++)
            {
                query = $"SELECT count (*) FROM AllWords WHERE Rating = {i};";
                cmd = new SQLiteCommand(query, connection);
                stat.allRatings[i] = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return stat;
        }
        #endregion

        #region Отримати / Змінити кількість слів для вивчення (за раз)

        public int GetWordsToLearnCount()
        {
            string query = $"SELECT WordCountToLearn FROM Settings;";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
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
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
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
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
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

            return reader.GetInt32(2) == 1 ? true : false;
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
