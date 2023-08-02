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
        public SQLiteDataReader GetDataReader(string query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            return cmd.ExecuteReader();
        }
        //*********************************************************************************************************

        #region [Категорії слів]

        //TEST
        #region Отримати / Змінити поточну категорію для додавання слів / Додати нову



        //TEST
        bool CategoryIsRepeated(string categoryName)
        {
            string query = $"SELECT * FROM WordCategories WHERE Name = '{categoryName}';";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //return cmd.ExecuteReader().HasRows;
            return GetDataReader(query).HasRows;
        }

        //TEST
        public bool AddNewCategory(string categoryName)
        {
            //string categoryTableName = string.Concat(categoryName.Split().Select(c => char.ToUpper(c[0]) + c.Substring(1)));
            if (CategoryIsRepeated(categoryName)) return false;

            //TODO - додавання нової категорії до таблиці категорій
            string query = $"INSERT INTO WordCategories (Name, CreationDate, Deleted, CanBeDeleted) VALUES ('{categoryName}', '{DateTime.Now:dd-MM-yyyy}', 0, 1);";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            GetDataReader(query);
            return true;
        }

        //TEST
        public int GetCurrentCategory()
        {
            string query = $"SELECT CurrentWordCategory FROM Settings;";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //return Convert.ToInt32(cmd.ExecuteScalar());
            return GetDataReader(query).GetInt32(0);
        }

        //TEST
        public void SetCurrentCategory(int currentCategoryID)
        {
            string query = $"UPDATE Settings SET CurrentWordCategory = {currentCategoryID} WHERE SettingsID = 1;";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            GetDataReader(query);
        }

        #endregion

        //TEST
        #region Отримати інформацію про Категорії слів

        /// <summary>
        /// Отрмати список категорій з БД де Count = number
        /// </summary>
        /// <returns>Список слів </returns>
        public List<DB_WordCategory> GetWordCategories()
        {
            string query = $"SELECT * FROM Categories ORDER BY CategoryID"; //LIMIT {number};";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            var reader = GetDataReader(query);
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
        #endregion

        //TEST
        #region Додати слово(слова) в категорію / Скасувати його(їх) додавання 

        //TEST
        bool WordIsRepeated_InCategory(int wordID, int categoryID)
        {
            string query = $"SELECT * FROM WordCategories WHERE WordID = '{wordID}' AND CategoryID = '{categoryID}';";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //return cmd.ExecuteReader().HasRows;
            return GetDataReader(query).HasRows;
        }

        //TEST
        public bool TryAddWord_ToCategory(int wordID, int categoryID)
        {
            if (WordIsRepeated_InCategory(wordID, categoryID)) return false;

            string query = $"INSERT INTO WordCategories (WordID, CategoryID) VALUES ({wordID}, {categoryID});";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            GetDataReader(query);
            return true;
        }

        //TEST
        public void RemoveLastWord_FromCategory(int count)
        {
            string query = $"DELETE FROM WordCategories ORDER BY AddedAt DESC LIMIT {count};";
            //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //SQLiteDataReader reader = cmd.ExecuteReader();
            GetDataReader(query);
        }
        #endregion

        #endregion

        //TESTED
        #region Додати слово в БД / Скасувати його(їх) додавання

        bool WordIsRepeated_InAllWords(string engW)
            => GetDataReader($"SELECT * FROM AllWords WHERE EngWord = '{engW}';").HasRows;

        public bool TryAddWord_ToAllWords(string engW, string uaW)
        {
            if (WordIsRepeated_InAllWords(engW)) return false;

            uaW = uaW.Replace("'", "''");
            var reader = GetDataReader(
                "INSERT INTO AllWords (EngWord, UaTranslation, Rating, Repetition) " +
                $"VALUES ('{engW}', '{uaW}', 0, 0); " +
                "SELECT last_insert_rowid();");
            reader.Read();
            int wordID = reader.GetInt32(0);

            //Додавання до основної категорії
            return TryAddWord_ToCategory(wordID, 1);
        }

        public void RemoveLastWord_Completely(int count)
        {
            List<int> wordIDsForRemoving = new List<int>();

            var reader = GetDataReader($"SELECT WordID FROM WordCategories ORDER BY WordID DESC, AddedAt DESC LIMIT {count};"); //Можна замінити WordID на AddedAt
            while (reader.Read())
                wordIDsForRemoving.Add(reader.GetInt32(0));

            for (int i = 0; i < wordIDsForRemoving.Count; i++)
            {
                GetDataReader($"DELETE FROM AllWords WHERE WordID = {wordIDsForRemoving[i]}");
                GetDataReader($"DELETE FROM WordCategories WHERE WordID = {wordIDsForRemoving[i]}");
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
            var reader = GetDataReader(query);
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
            GetDataReader(query);
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
            GetDataReader(query);
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
            GetDataReader(query);
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
            GetDataReader(query);
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
            var reader = GetDataReader(query);
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
            GetDataReader(query);
        }
        #endregion
    }
}
