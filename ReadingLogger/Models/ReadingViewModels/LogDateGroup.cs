using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReadingLogger.Models.ReadingViewModels
{
    public class LogDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? LogDate { get; set; }
        public int ID { get; set; }
        public int TotalMinutes { get; set; }
        public int WeeklyMinutes { get; set; }
        public string StudentName { get; set; }

        
    }
}
