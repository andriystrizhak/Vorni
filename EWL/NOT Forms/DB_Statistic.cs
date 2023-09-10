using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eng_Flash_Cards_Learner.NOT_Forms
{
    public class DB_Statistic
    {
        public int AllWordCount { get; set; }

        public int Rating5 { get; set; }
        public int Rating4 { get; set; }
        public int Rating3 { get; set; }
        public int Rating2 { get; set; }
        public int Rating1 { get; set; }
        public int NotLearned { get; set; }

        public int[] AllRatings = new int[6];
    }
}
