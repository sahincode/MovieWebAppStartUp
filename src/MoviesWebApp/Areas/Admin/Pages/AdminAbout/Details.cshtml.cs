using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data;
using MoviesWebApp.Data.DAL;


namespace MoviesWebApp.Areas.Admin.Pages.AdminAbout
{
    public class DetailsModel : PageModel
    {
        private readonly MoviesWebAppContext _context;

        public DetailsModel(MoviesWebAppContext context)
        {
            _context = context;
        }

      public About LogoPageInfo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LogoPageInfo == null)
            {
                return NotFound();
            }

            var logopageinfo = await _context.LogoPageInfo.FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
