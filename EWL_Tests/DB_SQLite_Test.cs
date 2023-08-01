using Eng_Flash_Cards_Learner;

namespace EWL_Tests
{
    [TestFixture]
    public class DB_SQLite_Test
    {
        public DB_SQLite db { get; set; } = new DB_SQLite("Data Source=.\\Test_DB.db;Version=3;");

        [SetUp]
        public void Setup()
        {
        }


        [TestCase("mummy", "матуся")]
        [TestCase("daddy", "татусь")]
        [TestCase("granny", "бабуся")]
        [TestCase("to do", "робити")]
        public void NewWordAdding_Test(string engW, string uaW)
        {
            if (!db.TryAddWord(engW, uaW)) Assert.Fail();

            string query = "SELECT * FROM AllWords";
            var reader = db.GetDataReader(query);
            reader.Read();
            //string tableEngW = reader.GetString(1);
            //string tableUaW = reader.GetString(2);
            Assert.AreEqual(reader.GetString(1), engW);
            Assert.AreEqual(reader.GetStream(2), uaW);
        }



        [TearDown]
        public void TearDown()
        {
            string query = $"DELETE FROM AllWords";
            db.GetDataReader(query);
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