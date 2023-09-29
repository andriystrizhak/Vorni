using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWL.NOT_Forms
{
    public class DB_Word
    {
        public int WordID { get; set; }
        public string? EngWord { get; set; }
        public string? UaTranslation { get; set; }
        public int Rating { get; set; }
        public int Repetition { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
