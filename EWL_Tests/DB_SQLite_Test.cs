using Eng_Flash_Cards_Learner;

namespace EWL_Tests
{
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

        [TestCase("mummy", "матуся")]
        [TestCase("daddy", "татусь")]
        [TestCase("granny", "бабуся")]
        public void NewWord_Adding_Test(string engW, string uaW)
        {
            //Перевірка на вдале додавання слова
            Assert.IsTrue(db.TryAdd_Word_ToAllWords(engW, uaW));

            //Перевірка на появу слів у базі
            var reader = db.Get_DataReader($"SELECT * FROM AllWords WHERE EngWord = '{engW}'");
            reader.Read();
            Assert.AreEqual(engW, reader.GetString(1));
            Assert.AreEqual(uaW, reader.GetString(2));

            //Перевірка на те чи було додане нове слово до Основної категорії
            bool isWordAddedToWordCategories = db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = '{reader.GetInt32(0)}';").HasRows;
            Assert.IsTrue(isWordAddedToWordCategories);
        }

        [TestCase("mummy", "матуся")]
        [TestCase("daddy", "татусь")]
        [TestCase("granny", "бабуся")]
        public void TwoIdenticalWords_Adding_Test(string engW, string uaW)
        {
            //Перевірка на вдале додавання слова
            Assert.IsTrue(db.TryAdd_Word_ToAllWords(engW, uaW));
            //Перевірка на НЕвдале ПОВТОРНЕ додавання слова
            Assert.IsFalse(db.TryAdd_Word_ToAllWords(engW, uaW));
        }

        [TestCase("mummy", "матуся")]
        [TestCase("daddy", "татусь")]
        [TestCase("granny", "бабуся")]
        public void LastWords_Removing_Test(string engW, string uaW)
        {
            //Додавання ДВОХ слів
            db.TryAdd_Word_ToAllWords("dick", "член");
            //Thread.Sleep(1000);
            db.TryAdd_Word_ToAllWords(engW, uaW);
            //Видалення останнього слова
            db.Remove_LastWords_FromAllWords(1);

            //Перевірка на те: чи було останнє додане слово видалене
            bool isLastAddedWordRemovedFromAllWords = !db.Get_DataReader($"SELECT * FROM AllWords WHERE EngWord = '{engW}'").HasRows;
            Assert.IsTrue(isLastAddedWordRemovedFromAllWords);
            //Перевірка на те: чи НЕ було інше слово видалене
            bool isAnotherWordNOTRemovedFromAllWords = db.Get_DataReader("SELECT * FROM AllWords WHERE EngWord = 'dick'").HasRows;
            Assert.IsTrue(isAnotherWordNOTRemovedFromAllWords);
            //Перевірка не те: чи було останнє додане слово видалене з категорій
            bool isLastAddedWordRemovedFromWordCategories = !db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = 4;").HasRows;
            Assert.IsTrue(isLastAddedWordRemovedFromWordCategories);
            //Перевірка не те: чи було інше слово видалене з категорій
            bool isAnotherWordRemovedFromWordCategories = db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = 3;").HasRows;
            Assert.IsTrue(isAnotherWordRemovedFromWordCategories);
        }
        #endregion

        #region Categories TESTS

        [TestCase(2)]
        [TestCase(1)]
        public void CurrentCategory_SettingAndGetting_Test(int categoryID)
        {
            //Налаштування значення CurrentCategoryID в Settings
            db.Set_CurrentCategory(categoryID);
            //Перевірка на зміну CurrentCategoryID в Settings
            var reader = db.Get_DataReader("SELECT CurrentCategoryID FROM Settings");
            reader.Read();
            int actualCurrentCategoryID = reader.GetInt32(0);
            Assert.AreEqual(categoryID, actualCurrentCategoryID);

            //Отримання значення CurrentCategoryID в Settings
            int gettedCurrentCategoryID = db.Get_CurrentCategory();
            //Перевірка на те чи значення CurrentCategoryID отрмується вірно
            int expectedCurrentCategoryID = actualCurrentCategoryID; //зміна призначення змінної
            Assert.AreEqual(expectedCurrentCategoryID, gettedCurrentCategoryID);
        }

        [Test]
        public void AllCategories_Getting_Test()
        {
            var categories = db.Get_Categories();
            Assert.AreEqual("AllWords", categories[0].Name);
        }

        [TestCase("Category 1")]
        [TestCase("Category 2")]
        public void NewCategory_Adding_Test(string categoryName)
        {
            //Перевірка на вдале додавання категорії
            Assert.IsTrue(db.Add_NewCategory(categoryName));
            //Перевірка на появу категорії у Categories
            bool isCategoryAdded = db.Get_DataReader($"SELECT * FROM Categories WHERE Name = '{categoryName}'").HasRows;
            Assert.IsTrue(isCategoryAdded);
        }

        [TestCase("Category 1")]
        [TestCase("Category 2")]
        public void TwoIdenticalCategories_Adding_Test(string categoryName)
        {
            //Перевірка на вдале додавання категорії
            Assert.IsTrue(db.Add_NewCategory(categoryName));
            //Перевірка на невдале ПОВТОРНЕ додавання категорії
            Assert.IsFalse(db.Add_NewCategory(categoryName));
        }
        #endregion

        #region WordCategories TESTS

        [TestCase("a", "ей")]
        [TestCase("b", "бі")]
        [TestCase("c", "сі")]
        public void Word_Adding_ToCategory_Test(string engW, string uaW)
        {
            //Перевірка на вдале додавання слова до іншої категорії
            Assert.IsTrue(db.TryAdd_Word_ToCategory(2, 2));

            //Перевірка на появу слова в певній категорії у WordCategories
            bool isAddedToCategory2 = db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = 2 AND CategoryID = 2;").HasRows;
            Assert.IsTrue(isAddedToCategory2);
        }

        [TestCase("mummy", "матуся")]
        [TestCase("daddy", "татусь")]
        [TestCase("granny", "бабуся")]
        public void TwoIdenticalWords_Adding_ToCategory_Test(string engW, string uaW)
        {
            //Перевірка на вдале додавання слова до іншої категорії
            Assert.IsTrue(db.TryAdd_Word_ToCategory(2, 2));
            //Перевірка на НЕвдале додавання слова до іншої категорії
            Assert.IsFalse(db.TryAdd_Word_ToCategory(2, 2));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Word_Removing_FromWordCategories_Test(int count)
        {
            //Додавання слова(-ів) до іншої категорії
            for (int i = 1; i <= count; i++)
                db.TryAdd_Word_ToCategory(i, 2);
            //Видалення останнього(-іх) доданого до іншої категорії слова з WordCategories
            db.Remove_LastWord_FromCategory(count);

            int allWordsCount = 2;
            for (int i = 1; i <= allWordsCount; i++)
            {
                if (i <= count)
                {
                    //Перевірка на те: чи були останні додані слова видаленi
                    bool isLastAddedWordRemovedFromAllWords = !db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = {i} AND CategoryID = 2").HasRows;
                    Assert.IsTrue(isLastAddedWordRemovedFromAllWords);
                }
                else
                {
                    //Перевірка на те: чи НЕ були інші слова видалені
                    bool isAnotherWordNOTRemovedFromAllWords = db.Get_DataReader($"SELECT * FROM WordCategories WHERE WordID = {i} AND CategoryID = 1").HasRows;
                    Assert.IsTrue(isAnotherWordNOTRemovedFromAllWords);
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