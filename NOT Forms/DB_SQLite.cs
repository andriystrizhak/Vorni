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

namespace Eng_Flash_Cards_Learner
{
    class DB_SQLite
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=.\\Vocabulary.db;Version=3;"); //D:\\SELF-DEV\\HARD-SKILLS\\DEVELOPMENT\\PRACTICE\\MyProjects\\Engish_Words_Learner_(flash-cards)

        public DB_SQLite()
            => OpenConnection();

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


        #region Додати слово / Скасувати його(їх) додавання

        bool WordIsNotRepeated(string engW)
        {
            string query = $"SELECT * FROM AllWords WHERE EngWord = '{engW}';";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = cmd.ExecuteReader();
            return reader.HasRows;
        }

        public bool TryAddWord(string engW, string uaW)
        {
            if (WordIsNotRepeated(engW)) return false;

            uaW = uaW.Replace("'", "''");
            string query = $"INSERT INTO AllWords (EngWord, UaTranslation, Rating, Repetition) VALUES ('{engW}', '{uaW}', 0, 0);";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);

            SQLiteDataReader reader = cmd.ExecuteReader();
            return true;
        }

        public void RemoveLastWord(int count)
        {
            string query = $"DELETE FROM AllWords ORDER BY WordID DESC LIMIT {count};";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
        }
        #endregion

        #region Отримати слова

        /// <summary>
        /// Отрмати список слів з БД де Count = number
        /// </summary>
        /// <param name="number">Кількість слів для вивчення</param>
        /// <returns>Список слів </returns>
        public List<DB_Word> GetWords(int number)
        {
            string query = $"SELECT * FROM AllWords ORDER BY Rating LIMIT {number};";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
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

        #region Оцінювати слово

        public void RateWord(int id, int number)
        {
            string query = $"UPDATE AllWords SET Rating = {number} WHERE WordID = {id};";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
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

        public void SetWordsToLearnCount(int count)
        {
            string query = $"UPDATE Settings SET WordCountToLearn = {count} WHERE SettingsID = 1;";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
        }
        #endregion

        #region Отримати / Змінити кількість слів для вивчення (за раз)

        public int GetWordAddingMode()
        {
            string query = $"SELECT WordAddingMode FROM Settings;";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void SetWordAddingMode(int mode)
        {
            string query = $"UPDATE Settings SET WordAddingMode = {mode} WHERE SettingsID = 1;";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
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
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
        }
        #endregion

        #region Отримати дані чи запускався цей додаток до цього, чи ні

        /// <summary>
        /// Показує чи поле "WasLaunched" має значення "1"
        /// </summary>
        /// <returns></returns>
        public bool WasLaunched()
        {
            string query = $"SELECT * FROM Settings;";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();

            return reader.GetInt32(2) == 1 ? true : false;
        }

        /// <summary>
        /// Змінює значення "WasLaunched" в таблиці "Settings" в БД
        /// </summary>
        /// <param name="wasLaunched">Значення поля "WasLaunched"</param>
        public void SetWasLaunched(bool wasLaunched)
        {
            string query = $"UPDATE Settings SET WasLaunched = { (wasLaunched ? 1 : 0) } WHERE SettingsID = 1;";
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
        }
        #endregion
    }
}
