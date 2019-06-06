using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReadingLogger.Models;

namespace ReadingLogger.Pages.Entries
{
    public class DetailsModel : PageModel
    {
        private readonly ReadingLogger.Models.LoggerContext _context;

        public DetailsModel(ReadingLogger.Models.LoggerContext context)
        {
            _context = context;
        }

        public Entry Entry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entry = await _context.Entry
                .Include(e => e.Student).FirstOrDefaultAsync(m => m.EntryID == id);

            if (Entry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
