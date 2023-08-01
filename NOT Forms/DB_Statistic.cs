using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eng_Flash_Cards_Learner.Logic
{
    public class DB_Statistic
    {
        public int allWordCount { get; set; }

        public int rating5 { get; set; }
        public int rating4 { get; set; }
        public int rating3 { get; set; }
        public int rating2 { get; set; }
        public int rating1 { get; set; }
        public int notLearned { get; set; }

        public int[] allRatings = new int[6];
    }
}
