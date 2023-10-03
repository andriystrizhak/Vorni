using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EWL.EF_SQLite;

namespace EWL.NOT_Forms
{
    static class Txt_FileHandler
    {
        //TODO
        // - Додати спеціальний формат для рядка зі складністю
        // - Додати можливість обробляти такий рядок
        // і встановлювати складність слова з нього

        /// <summary>
        /// Розділяє рядок на слово і його переклад
        /// </summary>
        public static Txt_Word SplitSpecialLine(string line)
        {
            string[] wordMeaningPair = line.Split(" - ");
            string meanings = wordMeaningPair[1].Replace(" / ", "\n");

            return new Txt_Word { Eng = wordMeaningPair[0], Ua = meanings };
        }

        /// <summary>
        /// Додає слова з .txt-файлу до БД
        /// </summary>
        /// <param name="pathToTxtFile">Шлях до .txt-файлу</param>
        /// <returns>Результати роботи методу: 
        /// Item1 - кількість слів в файлі,
        /// Item2 - кількість доданих до БД слів</returns>
        public static (int, int) AddWordsFromTxtFile(string pathToTxtFile)
        {
            string[] allLines = File.ReadAllLines(pathToTxtFile);

            var allWords = allLines
                .Where(x => x.Contains(" - "))
                .Select(x => SplitSpecialLine(x))
                .ToList();
            int addedWordsCount = 0;

            foreach (var word in allWords)
                addedWordsCount += SQLs.TryAdd_Word_ToAllWords(word.Eng, word.Ua) ? 1 : 0;

            return (allWords.Count, addedWordsCount);
        }
    }
}
