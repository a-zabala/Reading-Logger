using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReadingLogger.Models
{
    public class ReadingLoggerContext : DbContext
    {
        public ReadingLoggerContext (DbContextOptions<ReadingLoggerContext> options)
            : base(options)
        {
        }

        public DbSet<ReadingLogger.Models.Entry> Entry { get; set; }
    }
}
