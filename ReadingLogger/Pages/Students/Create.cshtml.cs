using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReadingLogger.Models;

namespace ReadingLogger.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ReadingLogger.Models.LoggerContext _context;

        public CreateModel(ReadingLogger.Models.LoggerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",     //Prefix for form Value.
                s => s.FirstName, s => s.LastName, s => s.Teacher, s => s.CurrentBook, s => s.Section))

            {
                _context.Student.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return null;
        }
    }

}