using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;

namespace MoviesWebApp.Areas.Admin.Pages.AdminAbout
{
    public class UpdateModel : PageModel
    {
        private readonly MoviesWebAppContext _context;

        public UpdateModel(MoviesWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public About LogoPageInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LogoPageInfo == null)
            {
                return NotFound();
            }

            var logopageinfo =  await _context.LogoPageInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (logopageinfo == null)
            {
                return NotFound();
            }
            LogoPageInfo = logopageinfo;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LogoPageInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogoPageInfoExists(LogoPageInfo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LogoPageInfoExists(int id)
        {
          return (_context.LogoPageInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
