using ReadingLogger.Models.ReadingViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadingLogger.Models;
using System;

namespace ReadingLogger.Pages.Students
{
    public class StatsModel : PageModel
    {
        private readonly LoggerContext _context;

        public StatsModel(LoggerContext context)
        {
            _context = context;
        }

        public IList<LogDateGroup> Entries { get; set; }

        public Student Student { get; set; }

        public async Task OnGetAsync(int studentId)
        {
            Student = _context.Student.FirstOrDefault(x => x.ID == studentId);

            IQueryable<LogDateGroup> data =
                _context.Entry.Where(x=>x.StudentID == studentId)
                .GroupBy(x => x.StudentID)
                .Select(x => new LogDateGroup
                {
                    ID = x.Key,
                    //StudentName = x.Student.FirstName + " " + x.Student.LastName,
                    TotalMinutes = x.Sum(y => y.Minutes),
                    WeeklyMinutes = x.Where(y => y.LogDate >= DateTime.Now.AddDays(-7)).Sum(z => z.Minutes)
                });

            IQueryable<LogDateGroup> data2 =
                from entry in _context.Entry
                group entry by entry.LogDate into dateGroup
                select new LogDateGroup()
                {
                    LogDate = dateGroup.Key,
                    WeeklyMinutes = dateGroup.Sum(y => y.Minutes)
                };

            Entries = await data.AsNoTracking().ToListAsync();
        }
    }
}