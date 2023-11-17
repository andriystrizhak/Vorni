using EWL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eng_Flash_Cards_Learner.NOT_Forms.LearningItems
{
    public class FCItem
    {
        public FCItem(Word word, string sentence)
        {
            WordId = word.WordId;
            EngW = word.EngWord;
            UaT = word.UaTranslation.Replace("\n", ", ");
            Rating = word.Rating;
            Sentence = sentence;
        }

        public int WordId {  get; set; }
        public string EngW { get; set; }
        public string UaT { get; set; }
        public int Rating { get; set; }
        public string Sentence { get; set; }

        public static List<FCItem> CreateFCItems(List<Word> words, List<string> sentenses)
        {
            if (words.Count != sentenses.Count)
                throw new ArgumentException("words.Count != sentenses.Count");

            var fcItems = new List<FCItem>();

            for (int i = 0; i < words.Count; i++)
                fcItems.Add(new FCItem(words[i], sentenses[i]));

            Random rng = new Random();
            int n = fcItems.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = fcItems[k];
                fcItems[k] = fcItems[n];
                fcItems[n] = value;
            }

            return fcItems;
        }
    }
}
