using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWL.NOT_Forms;

namespace EWL_Tests
{
    [TestFixture]
    public class TxtHandler_Test
    {
        [TestCase("Bilibirda")]
        [TestCase("Bilibirda - ")]
        [TestCase("Bilibirda -  ")]
        [TestCase(" - bilibirda")]
        [TestCase("  - bilibirda")]
        [TestCase("-")]
        [TestCase(" -")]
        [TestCase("- ")]
        [TestCase(" - ")]
        [TestCase("  -  ")]
        public void InvalidLineFormat(string line)
        {
            var word = Txt_FileHandler.GetWordFromLine(line);
            Assert.AreEqual(null, word);
        }

        /// <summary>
        /// Правильний формат рядка (без складності)
        /// </summary>
        /// <param name="line">Рядок для перетворення в TxtWord</param>
        /// <param name="expEng">Очікуване значення Eng</param>
        /// <param name="expUa">Очікуване значення Ua</param>
        [TestCase("mother - мама", "mother", "мама")]
        [TestCase("father - тато", "father", "тато")]
        public void ValidLineFormat(string line, string expEng, string expUa)
        {
            var word = Txt_FileHandler.GetWordFromLine(line);
            Assert.AreNotEqual(null, word);
            Assert.AreEqual(expEng, word.Eng);
            Assert.AreEqual(expUa, word.Ua);
        }

        [TestCase("mother - мама [")]
        [TestCase("mother - мама [1")]
        [TestCase("mother - мама [0]")]
        [TestCase("mother - мама [6]")]
        [TestCase("mother - мама [")]

        public void InvalidLineBracketsFormat(string line)
        {
            var word = Txt_FileHandler.GetWordFromLine(line);
            Assert.AreEqual(null, word);
        }

        [TestCase("mother - мама [3]", 3)]
        [TestCase("father - тато [4]  ", 4)]
        public void ValidLineBracketsFormat(string line, int expDifficulty)
        {
            var word = Txt_FileHandler.GetWordFromLine(line);
            Assert.AreNotEqual(null, word);
            Assert.AreEqual(expDifficulty, word.Difficulty);
        }
    }
}
