using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eng_Flash_Cards_Learner.NOT_Forms
{
    public class DB_WordCategory
    {
        public int CategoryID { get; set; }
        public string CategoryTableName { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool CanBeDeleted { get; set; }
    }
}
