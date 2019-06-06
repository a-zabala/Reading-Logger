using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingLogger.Models
{
    public class Entry
    {
        public int EntryID { get; set; }
       // public int SectionID { get; set; }
        public int StudentID { get; set; }
        public string Book { get; set; }
        public int Minutes { get; set; }

        public int Pages { get; set; }
        [DataType(DataType.Date)]
        public DateTime LogDate { get; set; }
        public Student Student { get; set; }
    }
}
