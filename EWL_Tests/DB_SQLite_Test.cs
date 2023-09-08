using Eng_Flash_Cards_Learner;
using System.Data.SQLite;
using NUnit.Framework;

namespace EWL_Tests
{
    /// <summary>
    /// Клас що містить тест-кейси
    /// </summary>
    public static class MyTestCases
    {
        /// <summary>
        /// Набір тест-кейсів з Категоріями
        /// </summary>
        /// <returns> IEnumerable категорій </returns>
        public static IEnumerable<TestCaseData> Categories_Cases()
        {
            yield return new TestCaseData("Category 1");
            yield return new TestCaseData("Category 2");
        }

        /// <summary>
        /// Набір тест-кейсів зі Словами
        /// </summary>
        /// <returns> IEnumerable слів </returns>
        public static IEnumerable<TestCaseData> Words_Cases()
        {
            yield return new TestCaseData("a", "ей");
            yield return new TestCaseData("b", "бі");
            yield return new TestCaseData("c", "сі");
        }
    }

    [TestFixture]
    public class DB_SQLite_Test
    {
        public DB_SQLite db { get; set; } = new DB_SQLite("Data Source=D:\\SELF-DEV\\HARD-SKILLS\\DEVELOPMENT\\PRACTICE\\MyProjects\\EWL FC\\EWL_Tests\\Test_DB.db;Version=3;");

        [SetUp]
        public void Setup()
            => TearDown();



        #region Words TESTS

        [TestCaseSource(typeof(MyTestCases), "Words_Cases")]
        public void NewWord_Adding_Test(string engW, string uaW)
        {
            Assert.IsTrue(db.TryAdd_Word_ToAllWords(engW, uaW),
                "Метод НЕ додав задане слово в AllWords");

            bool isAddedToAllWords = db.Get_DataReader($"SELECT * FROM AllWords " +
                $"WHERE EngWord = '{engW}' AND UaTranslation = '{uaW}'").HasRows;
            Assert.IsTrue(isAddedToAllWords,
                "Задане слово НЕ було додане в БД");

            bool isWordAddedToWordCategories = db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = 3;").HasRows;
            Assert.IsTrue(isWordAddedToWordCategories,
                "Задане слово не було додане до категорії '1' в WordCategories");
        }

        [TestCaseSource(typeof(MyTestCases), "Words_Cases")]
        public void TwoIdenticalWords_Adding_Test(string engW, string uaW)
        {
            Assert.IsTrue(db.TryAdd_Word_ToAllWords(engW, uaW),
                "Метод НЕ додав задане слово в AllWords");
            Assert.IsFalse(db.TryAdd_Word_ToAllWords(engW, uaW),
                "Метод додав задане слово в AllWords [а не повинен був]");
        }

        [TestCaseSource(typeof(MyTestCases), "Words_Cases")]
        public void LastWords_Removing_Test(string engW, string uaW)
        {
            db.TryAdd_Word_ToAllWords("dick", "член");       //Додавання першого слова
            db.TryAdd_Word_ToAllWords(engW, uaW);            //Додавання другого слова
            db.Remove_LastWords_Permanently(1);              //Видалення останнього слова

            //Перевірки
            bool isLastAddedWordRemovedFromAllWords = !db.Get_DataReader($"SELECT * FROM AllWords WHERE EngWord = '{engW}'").HasRows;
            Assert.IsTrue(isLastAddedWordRemovedFromAllWords, "Останнє слово НЕ було видалене");

            bool isAnotherWordNOTRemovedFromAllWords = db.Get_DataReader("SELECT * FROM AllWords WHERE EngWord = 'dick'").HasRows;
            Assert.IsTrue(isAnotherWordNOTRemovedFromAllWords, "Інше слово було видалене [а не повинне бути]");

            bool isLastAddedWordRemovedFromWordCategories = !db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = 4;").HasRows;
            Assert.IsTrue(isLastAddedWordRemovedFromWordCategories, "Останнє слово НЕ було видалене з WordCategories");

            bool isAnotherWordRemovedFromWordCategories = db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = 3;").HasRows;
            Assert.IsTrue(isAnotherWordRemovedFromWordCategories, "Інше слово було видалене з WordCategories [а не повинне бути]");
        }

        [TestCaseSource(typeof(MyTestCases), "Words_Cases")]
        public void Word_Removing_Test(string engW, string uaW)
        {
            db.TryAdd_Word_ToAllWords("dick", "член");      //Додавання першого слова
            db.TryAdd_Word_ToAllWords(engW, uaW);           //Додавання другого слова
            db.Remove_Word_Permanently(4);                  //Видалення другого слова

            //Перевірки
            bool isLastAddedWordRemovedFromAllWords = !db.Get_DataReader($"SELECT * FROM AllWords WHERE EngWord = '{engW}'").HasRows;
            Assert.IsTrue(isLastAddedWordRemovedFromAllWords, "Друге слово НЕ було видалене");

            bool isAnotherWordNOTRemovedFromAllWords = db.Get_DataReader("SELECT * FROM AllWords WHERE EngWord = 'dick'").HasRows;
            Assert.IsTrue(isAnotherWordNOTRemovedFromAllWords, "Перше слово було видалене [а не повинне бути]");

            bool isLastAddedWordRemovedFromWordCategories = !db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = 4;").HasRows;
            Assert.IsTrue(isLastAddedWordRemovedFromWordCategories, "Друге слово НЕ було видалене з WordCategories");

            bool isAnotherWordRemovedFromWordCategories = db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = 3;").HasRows;
            Assert.IsTrue(isAnotherWordRemovedFromWordCategories, "Перше слово було видалене з WordCategories [а не повинне бути]");
        }

        #endregion

        #region Categories [TESTS]

        [TestCase(2)]
        [TestCase(1)]
        public void CurrentCategory_SettingAndGetting_Test(int categoryID)
        {
            db.Set_CurrentCategory(categoryID);        //Налаштування значення CurrentCategoryID в Settings

            //Перевірки
            var reader = db.Get_DataReader("SELECT CurrentCategoryID FROM Settings");
            reader.Read();
            int actualCurrentCategoryID = reader.GetInt32(0);
            Assert.AreEqual(categoryID, actualCurrentCategoryID,
                "CurrentCategoryID НЕ встановлене із необхідним значенням");

            int gettedCurrentCategoryID = db.Get_CurrentCategory();   //Отримання значення CurrentCategoryID в Settings
            int expectedCurrentCategoryID = actualCurrentCategoryID; //зміна призначення змінної
            Assert.AreEqual(expectedCurrentCategoryID, gettedCurrentCategoryID,
                "Отримане значення CurrentCategoryID - НЕ вірне");
        }

        [Test]
        public void AllCategories_Getting_Test()
        {
            var categories = db.Get_Categories();
            Assert.AreEqual("AllWords", categories[0].Name,
                "Отриманий список інформації про категорії - НЕ вірний");
        }

        #region Categories Adding [TESTS]

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void NewCategory_Adding_Test(string categoryName)
        {
            Assert.IsTrue(db.Add_NewCategory(categoryName),
                "Додавання нової категорії НЕ вдале");
            bool isCategoryAdded = db.Get_DataReader($"SELECT * FROM Categories WHERE Name = '{categoryName}'").HasRows;
            Assert.IsTrue(isCategoryAdded,
                "Нова категорія не з'явилася в Categories");
        }

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void TwoIdenticalCategories_Adding_Test(string categoryName)
        {
            Assert.IsTrue(db.Add_NewCategory(categoryName),
                "Додавання нової категорії НЕ вдале");
            Assert.IsFalse(db.Add_NewCategory(categoryName),
                "Додавання нової категорії вдале [а не повинне бути]");
        }

        #endregion

        #region Categories Marking as Removed [TESTS]

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void Category_MarkingAsRemoved_Test(string categoryName)
        {
            int categoryID = 3;
            db.Add_NewCategory(categoryName);          //Додавання нової категорії (3-тя)
            db.Set_CurrentCategory(categoryID);        //Встановлення поточної категорії - '3'

            //Перевірки
            Assert.IsTrue(db.TryMarkAsRemoved_Category(categoryID), 
                "Задана категорія НЕ була (позначена як) видалена");

            var reader = db.Get_DataReader($"SELECT Deleted, DeletedAt FROM Categories WHERE CategoryID = {categoryID}");
            reader.Read();
            bool categoryIsMarkedAsDeleted = reader.GetInt32(0) == 1;
            Assert.IsTrue(categoryIsMarkedAsDeleted, 
                "Значення поля 'Deleted' заданої категорії НЕ змінилося на '1'");

            Assert.AreEqual(1, db.Get_CurrentCategory(), 
                "CurrentCategoryID в Settings НЕ змінилося на дефолтне '1'");

            string actualDateTime = reader.GetString(1);
            Assert.IsTrue(actualDateTime.Contains($"{DateTime.Now:yyyy-MM-dd HH:mm}"),
                "Дата не встановлена або встановлена НЕвірно");
        }

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void NonRemovableCategory_NOTMarkingAsRemoved_Test(string categoryName)
        {
            int categoryID = 3;
            db.Get_DataReader($"INSERT INTO Categories (Name, Deleted, CanBeDeleted) " +
                $"VALUES ('{categoryName}', 0, 0);");              //Додавання категорії, яку не можна видаляти

            //Перевірки
            Assert.IsFalse(db.TryMarkAsRemoved_Category(categoryID), 
                "Дана категорія була (позначена як) видалена [а не повинна була]");

            var reader = db.Get_DataReader($"SELECT Deleted FROM Categories WHERE CategoryID = {categoryID}");
            reader.Read();
            bool categoryIsMarkedAsDeleted = reader.GetInt32(0) == 1;
            Assert.IsFalse(categoryIsMarkedAsDeleted,
                "Значення поля 'Deleted' заданої категорії змінилося на '1' [а не повинно було]");
        }
        #endregion

        #region Categories Restoring from Deletion [TESTS]

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void Category_Restoring_FromDeletion_Test(string categoryName)
        {
            int categoryID = 3;
            db.Add_NewCategory(categoryName);           //Додавання нової категорії (3-тя)
            db.Set_CurrentCategory(categoryID);         //Встановлення поточної категорії - '3'
            db.TryMarkAsRemoved_Category(categoryID);   //Позначення категорії як "Видалена"

            db.Restore_Category_FromDeletion(categoryID);   //Відновлення категорії з "Кошика"

            var reader = db.Get_DataReader($"SELECT Deleted FROM Categories WHERE CategoryID = {categoryID}");
            reader.Read();
            bool categoryIsMarkedAsDeleted = reader.GetInt32(0) == 1;
            Assert.IsFalse(categoryIsMarkedAsDeleted,
                "Значення поля 'Deleted' заданої категорії НЕ змінилося на '0'");

            Assert.AreEqual(1, db.Get_CurrentCategory(),
                "CurrentCategoryID в Settings змінилося з дефолтного '1' на інше [а не повинне було]");
        }
        #endregion

        #region Categories Removing [TESTS]

        public (string query1, string query2) MarkedCategories_Removing_Test(string categoryName)
        {
            int categoryID = 3;
            db.Add_NewCategory(categoryName);           //Додавання нової категорії (3-тя)
            db.TryAdd_Word_ToCategory(1, categoryID);   //Додавання першого слова до нової категорії
            db.TryAdd_Word_ToCategory(2, categoryID);   //Додавання другого слова до нової категорії
            db.TryMarkAsRemoved_Category(categoryID);   //Позначення категорії як "видалена"

            return ($"SELECT * FROM WordCategories WHERE CategoryID = '{categoryID}'",
                $"SELECT * FROM Categories WHERE CategoryID = '{categoryID}'");
        }

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void RecentlyMarkedCategories_Removing_Test(string categoryName)
        {
            var queries = MarkedCategories_Removing_Test(categoryName);

            //Перевірки
            db.FindAndRemove_LongMarkedCategories(3);

            bool isRecentlyMarkedCategoryWordsDeleted = !db.Get_DataReader(queries.query1).HasRows;
            Assert.IsFalse(isRecentlyMarkedCategoryWordsDeleted, 
                "Слова даної категорії видалені з WordCategory [а НЕ повинні бути]");

            bool isRecentlyMarkedCategoryDeleted = !db.Get_DataReader(queries.query2).HasRows;
            Assert.IsFalse(isRecentlyMarkedCategoryDeleted, 
                "Дана категорія видалена з Categories [а НЕ повинна бути]");
        }

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void LongMarkedCategories_Removing_Test(string categoryName)
        {
            int categoryID = 3;
            var queries = MarkedCategories_Removing_Test(categoryName);

            //Зміна дати (позначення як) видалення даної категорії
            db.Get_DataReader($"UPDATE Categories " +
                $"SET DeletedAt = '{new DateTime(2023, 01, 01):yyyy-MM-dd HH:mm:ss}' WHERE CategoryID = {categoryID}");
            db.FindAndRemove_LongMarkedCategories(3);

            //Перевірка
            db.FindAndRemove_LongMarkedCategories(1);
            bool isLongMarkedCategoryWordsDeleted = !db.Get_DataReader(queries.query1).HasRows;
            Assert.IsTrue(isLongMarkedCategoryWordsDeleted,
                "Слова даної категорії НЕ видалені з WordCategory");

            bool isLongMarkedCategoryDeleted = !db.Get_DataReader(queries.query2).HasRows;
            Assert.IsTrue(isLongMarkedCategoryDeleted,
                "Дана категорія НЕ видалена з Categories");
        }
        #endregion

        #endregion

        #region WordCategories [TESTS]

        [TestCase(1)]
        [TestCase(2)]
        public void Word_Adding_ToCategory_Test(int wordID)
        {
            int anotherCategoryID = 2;

            //Перевірки
            Assert.IsTrue(db.TryAdd_Word_ToCategory(wordID, anotherCategoryID), 
                "Метод НЕ додав слово до категорії '2'");

            bool isAddedToCategory2 = db.Get_DataReader($"SELECT * FROM WordCategories " +
                $"WHERE WordID = {wordID} AND CategoryID = {anotherCategoryID};").HasRows;
            Assert.IsTrue(isAddedToCategory2, "Слово НЕ з'явилося в категорії '2'");
        }

        [TestCaseSource(typeof(MyTestCases), "Words_Cases")]
        public void TwoIdenticalWords_Adding_ToCategory_Test(string engW, string uaW)
        {
            int anotherWordID = 2;
            int anotherCategoryID = 2;

            Assert.IsTrue(db.TryAdd_Word_ToCategory(anotherWordID, anotherCategoryID), 
                "Метод НЕ додав слово до категорії '2'");
            Assert.IsFalse(db.TryAdd_Word_ToCategory(anotherWordID, anotherCategoryID), 
                "Метод додав ІДЕНТИЧНЕ слово до категорії '2' [а не повинен]");
        }

        /// <summary>
        /// Перевіряє чи виникне виключення якщо додати до категорії слово з неправильним номером wordID чи categoryID
        /// </summary>
        /// <param name="invalidNumber">неправильний номер для wordID чи categoryID</param>
        [TestCase(0)]
        [TestCase(-2)]
        public void InvalidNumber_Word_Adding_ToCategory_Test(int invalidNumber)
        {
            int validWordID = 2;
            int validCategoryID = 2;

            TestDelegate AddValidWordIDToInvalidCategoryID = () => db.TryAdd_Word_ToCategory(validWordID, invalidNumber);
            Assert.Catch(typeof(ArgumentException), AddValidWordIDToInvalidCategoryID,
                "Тут повинне виникати виключення, а не виникає");

            TestDelegate AddInvalidWordIDToValidCategoryID = () => db.TryAdd_Word_ToCategory(invalidNumber, validCategoryID);
            Assert.Catch(typeof(ArgumentException), AddInvalidWordIDToValidCategoryID,
                "Тут повинне виникати виключення, а не виникає");

            TestDelegate AddInvalidWordIDToInvalidCategoryID = () => db.TryAdd_Word_ToCategory(invalidNumber, invalidNumber);
            Assert.Catch(typeof(ArgumentException), AddInvalidWordIDToInvalidCategoryID,
                "Тут повинне виникати виключення, а не виникає");

        }

        [TestCase(1)]
        [TestCase(2)]
        public void LastAddedWord_Removing_FromWordCategories_Test(int count)
        {
            int categoryID = 2;
            for (int i = 1; i <= count; i++)
                db.TryAdd_Word_ToCategory(i, categoryID);        //Додавання слова(-ів) до іншої категорії
            db.Remove_LastWord_FromCategory(count);     //Видалення останнього(-іх) доданого до іншої категорії слова з WordCategories

            int allWordsCount = 2;
            for (int i = 1; i <= allWordsCount; i++)
            {
                if (i <= count)
                {
                    bool isLastAddedWordRemovedFromAllWords = !db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = {i} AND CategoryID = 2").HasRows;
                    Assert.IsTrue(isLastAddedWordRemovedFromAllWords, "Останні додані слова НЕ були видалені");
                }
                else
                {
                    bool isAnotherWordNOTRemovedFromAllWords = db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = {i} AND CategoryID = 1").HasRows;
                    Assert.IsTrue(isAnotherWordNOTRemovedFromAllWords, "Інші слова були видалені [а не повинні бути]");
                }
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Word_Removing_FromWordCategories_Test(int wordID)
        {
            //TODO - реалізувати тест "Видалення слова з категорії"
            int categoryID = 2;                                  //Номер неосновної категорії
            db.TryAdd_Word_ToCategory(wordID, categoryID);       //Додавання слова(-ів) до іншої категорії
            db.Remove_Word_FromCategory(wordID, 1);              //Спроба видалення слова з основної категорії

            //Перевірка
            bool isWordNOTRemovedFromAllWordsCategory = db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = {wordID} AND CategoryID = 1").HasRows;
            Assert.IsTrue(isWordNOTRemovedFromAllWordsCategory, "Cлово було видалене з основної категорії [а не повинне було]");

            db.Remove_Word_FromCategory(wordID, categoryID);     //Видалення слова з неосновної категорії

            //Перевірка
            bool isWordRemovedFromAnotherCategory = !db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = {wordID} AND CategoryID = 2").HasRows;
            Assert.IsTrue(isWordRemovedFromAnotherCategory, "Слово НЕ було видалене з НЕосновної категорії");
        }


        #region WordCategories - Get Words from Category [TESTS]

        /// <summary>
        /// Додавання слів до БД (й половини з них до побічної категорії '2')
        /// </summary>
        /// <param name="wordCount">Кількість слів</param>
        void Words_Adding_ToDB(int wordCount)
        {
            int anotherCategoryID = 2;
            int alreadyAddedWordsCount = 2;

            for (int i = 0; i < wordCount; i++)
                db.TryAdd_Word_ToAllWords($"{i + 1}", "i + 1");
            for (int i = 0; i < wordCount + alreadyAddedWordsCount; i++)
                if (i % 2 == 0)
                    db.TryAdd_Word_ToCategory(i + 1, anotherCategoryID);
        }

        [TestCase(4)]
        [TestCase(6)]
        public void Words_Getting_FromMainCategory_Test(int addedWordCount)
        {
            int getWordsCount = 4;
            int categoryID = 1;
            Words_Adding_ToDB(addedWordCount);

            var allWFromCategory = db.Get_Words_FromCategory(categoryID);
            Assert.AreEqual(addedWordCount + 2, allWFromCategory.Count, 
                $"Отриманих слів має бути {addedWordCount + 2} а не {allWFromCategory.Count}");

            var countWFromCategory = db.Get_Words_FromCategory(categoryID, getWordsCount);
            Assert.AreEqual(getWordsCount, countWFromCategory.Count, 
                $"Отриманих слів має бути {getWordsCount} а не {allWFromCategory.Count}");
        }

        [TestCase(4)]
        [TestCase(6)]
        public void Words_Getting_FromAnotherCategory_Test(int addedWordCount)
        {
            int getWordsCount = 2;
            int categoryID = 2;
            Words_Adding_ToDB(addedWordCount);

            var allWFromCategory = db.Get_Words_FromCategory(categoryID);
            //int addedWordCount
            Assert.AreEqual((int)Math.Round(((double)addedWordCount + 2)/2, MidpointRounding.AwayFromZero), allWFromCategory.Count,
                $"Отриманих слів має бути {addedWordCount + 2} а не {allWFromCategory.Count}");

            var countWFromCategory = db.Get_Words_FromCategory(categoryID, getWordsCount);
            Assert.AreEqual(getWordsCount, countWFromCategory.Count,
                $"Отриманих слів має бути {addedWordCount + 2} а не {allWFromCategory.Count}");   
        }

        [TestCase(4)]
        [TestCase(6)]
        public void Words_NOTGetting_FromAnotherCategory_Test(int addedWordCount)
        {
            Words_Adding_ToDB(addedWordCount);
            int nonexistentWordCount = -2;
            TestDelegate GetWordsFromNonexistentCategory = () => db.Get_Words_FromCategory(2, nonexistentWordCount);

            Assert.Catch(typeof(ArgumentException), GetWordsFromNonexistentCategory, 
                "Тут повинне виникати виключення, а не виникає");
        }

        #endregion

        #endregion

        //TODO - Додавати ТЕСТИ ...






        [TearDown]
        public void TearDown()
        {
            db.Get_DataReader("DELETE FROM WordCategories WHERE AddedAt NOT IN ( SELECT AddedAt FROM WordCategories ORDER BY AddedAt LIMIT 2);");
            db.Get_DataReader("DELETE FROM AllWords WHERE WordID NOT IN ( SELECT WordID FROM AllWords ORDER BY WordID LIMIT 2);");
            db.Get_DataReader("DELETE FROM Categories WHERE CategoryID NOT IN ( SELECT CategoryID FROM Categories ORDER BY CategoryID LIMIT 2);");
        }

        /*
        [TestCase("Programming Table", "ProgrammingTable")]
        [TestCase("programming table", "ProgrammingTable")]
        [TestCase("wild Animals", "WildAnimals")]
        [TestCase("daily vocab", "DailyVocab")]
        public void CategoryTableNameCreation_Test(string categoryName, string categoryTableName)
        {
            string createdCategoryTableName = string.Concat(categoryName.Split().Select(c => char.ToUpper(c[0]) + c.Substring(1)));
            Assert.AreEqual(categoryTableName, createdCategoryTableName);
        }
        */
    }
}