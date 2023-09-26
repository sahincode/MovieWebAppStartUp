﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;

namespace MoviesWebApp.Models.LogoinfoModel
{
    public class DeleteModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public DeleteModel(MoviesWebApp.Data.MoviesWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public LogoPageInfo LogoPageInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LogoPageInfo == null)
            {
                return NotFound();
            }

            var logopageinfo = await _context.LogoPageInfo.FirstOrDefaultAsync(m => m.ID == id);

            if (logopageinfo == null)
            {
                return NotFound();
            }
            else 
            {
                LogoPageInfo = logopageinfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.LogoPageInfo == null)
            {
                return NotFound();
            }
            var logopageinfo = await _context.LogoPageInfo.FindAsync(id);

            if (logopageinfo != null)
            {
                LogoPageInfo = logopageinfo;
                _context.LogoPageInfo.Remove(LogoPageInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
