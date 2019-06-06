using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReadingLogger.Models;

namespace ReadingLogger.Pages.Entries
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
        ViewData["StudentID"] = new SelectList(_context.Student, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Entry Entry { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Entry.Add(Entry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}