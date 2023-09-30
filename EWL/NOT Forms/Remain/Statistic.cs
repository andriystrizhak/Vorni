using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWL.NOT_Forms
{
    public class Statistic
    {
        /// <summary>
        /// Містить статистику по прогресу вивчення слів 
        /// (в конструктор передавати масив з 7-ма елементами)
        /// </summary>
        public Statistic(int[] allRatings)
        {
            AllRatings = allRatings;
            NotLearned = allRatings[0];
            //Rating1 = allRatings[1];
            //Rating2 = allRatings[2];
            //Rating3 = allRatings[3];
            //Rating4 = allRatings[4];
            //Rating5 = allRatings[5];
            AllWordCount = allRatings[6];
        }

        public int AllWordCount { get; set; }

        //REMOVE
        //public int Rating5 { get; private set; }
        //public int Rating4 { get; private set; }
        //public int Rating3 { get; private set; }
        //public int Rating2 { get; private set; }
        //public int Rating1 { get; private set; }
        public int NotLearned { get; private set; }

        public int[] AllRatings { get; private set; }
    }
}
