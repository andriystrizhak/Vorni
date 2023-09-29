using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWL.NOT_Forms
{
    public class DB_WordCategory
    {
        public int CategoryID { get; set; }
        //public string CategoryTableName { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool CanBeDeleted { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
