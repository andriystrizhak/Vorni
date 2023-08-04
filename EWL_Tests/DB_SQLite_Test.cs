using Eng_Flash_Cards_Learner;
using System.Data.SQLite;

namespace EWL_Tests
{
    /// <summary>
    /// Клас що містить тест-кейси
    /// </summary>
    public static class MyTestCases
    {
        public static IEnumerable<TestCaseData> Categories_Cases()
        {
            yield return new TestCaseData("Category 1");
            yield return new TestCaseData("Category 2");
        }

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
        {
            TearDown();
        }


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
            db.Remove_LastWords_FromAllWords(1);             //Видалення останнього слова

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
        #endregion

        #region Categories TESTS

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





        //перевірити автоматичне видалення категорій давно позначених як "Видалені"
        #endregion

        #region WordCategories TESTS

        public void Word_Adding_ToCategory_Test()
        {
            int anotherWordID = 2;
            int anotherCategoryID = 2;

            //Перевірки
            Assert.IsTrue(db.TryAdd_Word_ToCategory(anotherWordID, anotherCategoryID), 
                "Метод НЕ додав слово до категорії '2'");

            bool isAddedToCategory2 = db.Get_DataReader($"SELECT * FROM WordCategories " +
                $"WHERE WordID = {anotherWordID} AND CategoryID = {anotherCategoryID};").HasRows;
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

        [TestCase(1)]
        [TestCase(2)]
        public void Word_Removing_FromWordCategories_Test(int count)
        {
            for (int i = 1; i <= count; i++)
                db.TryAdd_Word_ToCategory(i, 2);        //Додавання слова(-ів) до іншої категорії
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

        #endregion







        [TearDown]
        public void TearDown()
        {
            db.Get_DataReader("DELETE FROM WordCategories WHERE AddedAt NOT IN ( SELECT AddedAt FROM WordCategories ORDER BY AddedAt LIMIT 2);");
            db.Get_DataReader("DELETE FROM AllWords WHERE WordID NOT IN ( SELECT WordID FROM AllWords ORDER BY WordID LIMIT 2);");
            db.Get_DataReader("DELETE FROM Categories WHERE CategoryID NOT IN ( SELECT CategoryID FROM Categories ORDER BY CategoryID LIMIT 2);");
        }







        [TestCase("Programming Table", "ProgrammingTable")]
        [TestCase("programming table", "ProgrammingTable")]
        [TestCase("wild Animals", "WildAnimals")]
        [TestCase("daily vocab", "DailyVocab")]
        public void CategoryTableNameCreation_Test(string categoryName, string categoryTableName)
        {
            string createdCategoryTableName = string.Concat(categoryName.Split().Select(c => char.ToUpper(c[0]) + c.Substring(1)));
            Assert.AreEqual(categoryTableName, createdCategoryTableName);
        }
    }
}