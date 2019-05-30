using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReadingLogger.Models.ReadingViewModels
{
    public class BookGroup
    {
        public String Book { get; set; }
        public int StudentCount { get; set; }
    }
}
