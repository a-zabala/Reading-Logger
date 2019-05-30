using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReadingLogger.Models
{
    public class LoggerContext : DbContext
    {
        public LoggerContext (DbContextOptions<LoggerContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Entry> Entry { get; set; }
        public DbSet<Section> Section { get; set; }
        
    }
}
