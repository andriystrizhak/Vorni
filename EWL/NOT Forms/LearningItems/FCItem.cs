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
        public FCItem(string engW, string uaT, string sentence)
        {
            EngW = engW;
            UaT = uaT;
            Sentence = sentence;
        }

        public string EngW { get; set; }
        public string UaT { get; set; }
        public string Sentence { get; set; }

        public static List<FCItem> CreateFCItems(List<Word> words, List<string> sentenses)
        {
            if (words.Count != sentenses.Count)
                throw new ArgumentException("words.Count != sentenses.Count");

            var fcItems = new List<FCItem>();

            for (int i = 0; i < words.Count; i++)
            {
                fcItems.Add(new FCItem(words[i].EngWord, words[i].UaTranslation, sentenses[i])); //(sentenses[i].First() == Convert.ToChar(i+1)) ? sentenses[i] : ""));
            }

            return fcItems;
        }
    }
}
