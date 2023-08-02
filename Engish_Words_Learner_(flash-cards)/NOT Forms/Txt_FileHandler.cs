using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Eng_Flash_Cards_Learner.Logic
{
    static class Txt_FileHandler
    {
        /// <summary>
        /// Розділяє рядок на Англ слово і його переклад
        /// </summary>
        public static Func<string, Txt_Word> SplitSpecialLine = x =>
        {
            string[] wordMeaningPair = x.Split(" - ");
            string meanings = wordMeaningPair[1].Replace(" / ", "\n");

            return new Txt_Word { Eng = wordMeaningPair[0], Ua = meanings };
        };

        /// <summary>
        /// Додає слова з .txt-файлу до БД
        /// </summary>
        /// <param name="pathToTxtFile">Шлях до .txt-файлу</param>
        /// <param name="db">Екземпляр класу DB_SQLite</param>
        /// <returns>Результати роботи методу: 
        /// Item1 - кількість слів в файлі;
        /// Item2 - кількість доданих до БД слів</returns>
        public static (int, int) AddWordsFromTxtFile(string pathToTxtFile, DB_SQLite db)
        {
            string[] allLines = File.ReadAllLines(pathToTxtFile);

            var allWords = allLines.Where(x => x.Contains(" - ")).Select(x => SplitSpecialLine(x)).ToList();
            int addedWordsCount = 0;

            foreach (var word in allWords)
                addedWordsCount += db.TryAddWord_ToAllWords(word.Eng, word.Ua) ? 1 : 0;

            return (allWords.Count, addedWordsCount);
        }
    }
}
