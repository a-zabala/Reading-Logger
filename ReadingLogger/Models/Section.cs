using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingLogger.Models
{
    
    public class Section
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SectionID { get; set; }
        public string Title { get; set; }
        public int Grade { get; set; }

        public ICollection<Entry> Entries { get; set; }
    }
}
