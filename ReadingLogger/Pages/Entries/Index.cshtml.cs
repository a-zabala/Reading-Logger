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
    public class IndexModel : PageModel
    {
        private readonly ReadingLogger.Models.LoggerContext _context;

        public IndexModel(ReadingLogger.Models.LoggerContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get;set; }

        public async Task OnGetAsync()
        {
            Entry = await _context.Entry
                .Include(e => e.Student).ToListAsync();
        }
    }
}
