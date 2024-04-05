using EWL.EF_SQLite;
using System.IO;

namespace EWL.NOT_Forms
{
    public static class Txt_FileHandler
    {
        static string[] separators = { " \u002D ", " \u2013 ", " \u2014 " }; //TODO - додати ЮТФ-ки всіх тирешок

        /// <summary>
        /// Розділяє рядок на слово, його переклад і складність (необов'язково)
        /// </summary>
        /// <param name="line">Рядок в спеціальному форматі</param>
        /// <returns>Слово типу <see cref="Txt_Word"/>, а якщо рядок некоректний то значення <see cref="null"/></returns>
        public static Txt_Word? GetWordFromLine(string line)
        {
            string[] wordMeaningsPair;
            string[] meaningDifficultyPair;
            int difficulty;
            string meanings;
            Txt_Word? word;

            try
            {
                wordMeaningsPair = line.Split(separators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
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
        /// Додає слова з <b>.txt-файлу</b> до БД
        /// </summary>
        /// <param name="filePath">Шлях до <b>.txt-файлу</b></param>
        /// <returns>Результати роботи методу: 
        /// <paramref name="Item1"/> - кількість слів в файлі,
        /// <paramref name="Item2"/> - кількість доданих до БД слів,
        /// <paramref name="Item3"/> - значення 1 або 0. Якщо шлях файлу коректний тоді - 1, інакше - 0</returns>
        public static (int, int, int) AddWordsFromTxtFile(string filePath)
        {
            (int, int, int) result = (0, 0, 1);
            if (!File.Exists(filePath))
                result.Item3 = 0;
            string[] allLines = File.ReadAllLines(filePath);

            var allWords = allLines
                .Where(x => separators.Any(s => x.Contains(s)))
                .Select(x =>
                { 
                    foreach (var s in separators)
                        x.Replace(s, " - ");
                    return x;
                })
                .Select(x => GetWordFromLine(x))
                .Where(x => x != null)
                .ToList();
            result.Item1 = allWords.Count;

            foreach (var word in allWords)
                result.Item2 += SQLService.TryAdd_Word_ToAllWords(
                    word.Eng, word.Ua, word.Difficulty) ? 1 : 0;

            return result;
        }

        /// <summary>
        /// Додає слова з кількох <b>.txt-файлів</b> до БД
        /// </summary>
        /// <param name="filesPaths">Список шляхів до <b>.txt-файлів</b></param>
        /// <returns>Результати роботи методу: 
        /// <paramref name="Item1"/> - сумарна кількість слів в файлах,
        /// <paramref name="Item2"/> - сумарна кількість доданих до БД слів,
        /// <paramref name="Item3"/> - кількість коректних файлів</returns>
        public static (int, int, int) AddWordsFromTxtFiles(List<string> filesPaths)
        {
            (int, int, int) results = (0, 0, 0);
            foreach (var filePath in filesPaths)
            {
                if (!filePath.Contains(".txt", StringComparison.OrdinalIgnoreCase))
                    continue;
                var result = AddWordsFromTxtFile(filePath);
                results.Item1 += result.Item1;
                results.Item2 += result.Item2;
                results.Item3 += result.Item3;
            }
            return results;
        }
    }
}
