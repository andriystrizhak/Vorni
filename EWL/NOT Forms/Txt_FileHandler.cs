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
    public static class Txt_FileHandler
    {
        /// <summary>
        /// Розділяє рядок на слово і його переклад
        /// </summary>
        public static Txt_Word? GetWordFromLine(string line)
        {
            string[] wordMeaningsPair;
            string[] meaningDifficultyPair;
            int difficulty;
            string meanings;
            Txt_Word? word;

            try
            {
                wordMeaningsPair = line.Split(" - ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                word = new Txt_Word();

                if (wordMeaningsPair[1].Contains("["))
                {
                    if (!wordMeaningsPair[1].Contains("]")) throw new ArgumentException("Wrong '[ ]' brackets format");

                    meaningDifficultyPair = wordMeaningsPair[1]
                        .Remove(wordMeaningsPair[1].IndexOf(']'))
                        .Split(" [", StringSplitOptions.RemoveEmptyEntries);
                    difficulty = int.Parse(meaningDifficultyPair[1]);

                    if (difficulty > 5 || difficulty < 1) throw new ArgumentException("Wrong Difficulty value");
                    word.Difficulty = difficulty;
                }
                meanings = wordMeaningsPair[1].Replace(" / ", "\n");

                word.Eng = wordMeaningsPair[0]; 
                word.Ua = meanings;
            }
            catch
            {
                word = null;
            }
            return word;
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
                .Select(x => GetWordFromLine(x))
                .Where(x => x != null)
                .ToList();
            int addedWordsCount = 0;

            foreach (var word in allWords)
                addedWordsCount += SQLs.TryAdd_Word_ToAllWords(word.Eng, word.Ua, word.Difficulty) ? 1 : 0;

            return (allWords.Count, addedWordsCount);
        }
    }
}
