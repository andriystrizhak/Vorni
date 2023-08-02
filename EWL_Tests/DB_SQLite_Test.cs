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


        [TestCase("mummy", "матуся")]
        [TestCase("daddy", "татусь")]
        [TestCase("granny", "бабуся")]
        public void NewWordAdding_Test(string engW, string uaW)
        {
            //Додавання слова
            if (!db.TryAddWord_ToAllWords(engW, uaW)) Assert.Fail();

            //Перевірка на появу слів у базі
            var reader = db.GetDataReader("SELECT * FROM AllWords");
            reader.Read();
            Assert.AreEqual(reader.GetString(1), engW);
            Assert.AreEqual(reader.GetString(2), uaW);

            //Перевірка на те чи було додане нове слово до Основної категорії
            var isWordAddedToWordCategories = db.GetDataReader($"SELECT * FROM WordCategories WHERE WordID = '{reader.GetInt32(0)}';").HasRows;
            Assert.IsTrue(isWordAddedToWordCategories);
        }

        [TestCase("mummy", "матуся")]
        [TestCase("daddy", "татусь")]
        [TestCase("granny", "бабуся")]
        public void LastWordsRemoving_Test(string engW, string uaW)
        {
            //Додавання ДВОХ слів
            db.TryAddWord_ToAllWords("dick", "член");
            //Thread.Sleep(1000);
            db.TryAddWord_ToAllWords(engW, uaW);
            //Видалення останнього слова
            db.RemoveLastWord_Completely(1);

            //Перевірка на те: чи було останнє додане слово видалене
            bool isLastAddedWordRemovedFromAllWords = !db.GetDataReader($"SELECT * FROM AllWords WHERE EngWord = '{engW}'").HasRows;
            Assert.IsTrue(isLastAddedWordRemovedFromAllWords);
            //Перевірка на те: чи НЕ було інше слово видалене
            bool isAnotherWordNOTRemovedFromAllWords = db.GetDataReader("SELECT * FROM AllWords WHERE EngWord = 'dick'").HasRows;
            Assert.IsTrue(isAnotherWordNOTRemovedFromAllWords);
            //Перевірка не те: чи було останнє додане слово видалене з категорій
            bool isLastAddedWordRemovedFromWordCategories = !db.GetDataReader($"SELECT * FROM WordCategories WHERE WordID = 2;").HasRows;
            Assert.IsTrue(isLastAddedWordRemovedFromWordCategories);
            //Перевірка не те: чи було інше слово видалене з категорій
            bool isAnotherWordRemovedFromWordCategories = db.GetDataReader($"SELECT * FROM WordCategories WHERE WordID = 1;").HasRows;
            Assert.IsTrue(isAnotherWordRemovedFromWordCategories);
        }





        [TearDown]
        public void TearDown()
        {
            db.GetDataReader($"DELETE FROM WordCategories");
            db.GetDataReader($"DELETE FROM AllWords");
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