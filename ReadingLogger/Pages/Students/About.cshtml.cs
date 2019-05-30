using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadingLogger.Models;
using ReadingLogger.Models.ReadingViewModels;

namespace ReadingLogger.Pages.Students
{
    public class AboutModel : PageModel
    {
        private readonly LoggerContext _context;

        public AboutModel(LoggerContext context)
        {
            _context = context;
        }

        public IList<BookGroup> Student { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<BookGroup> data =
                from student in _context.Student
                group student by student.CurrentBook into bookGroup
                select new BookGroup()
                {
                    Book = bookGroup.Key,
                    StudentCount = bookGroup.Count()

                };

            Student = await data.AsNoTracking().ToListAsync();

        }
    }
}
