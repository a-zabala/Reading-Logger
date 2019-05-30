using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReadingLogger.Models;

namespace ReadingLogger.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly LoggerContext _context;

        public IndexModel(LoggerContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string TeacherSort { get; set; }
        public string BookSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Student> Student { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex )
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TeacherSort = String.IsNullOrEmpty(sortOrder) ? "teacher_desc": "";
            BookSort = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<Student> studentIQ = from s in _context.Student
                                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(s => s.LastName.Contains(searchString)
                                                            || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.LastName);
                    break;
                case "teacher_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.Teacher);
                    break;
                case "book_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.CurrentBook);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.LastName);
                    break;

            }
            int pageSize = 25;

            Student = await PaginatedList<Student>.CreateAsync(
                studentIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
