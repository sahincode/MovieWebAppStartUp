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
    public class IndexModel : PageModel
    {
        private readonly MoviesWebAppContext _context;

        public IndexModel(MoviesWebAppContext context)
        {
            _context = context;
        }

        public IList<LogoPageInfo> LogoPageInfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.LogoPageInfo != null)
            {
                LogoPageInfo = await _context.LogoPageInfo.ToListAsync();
            }
        }
    }
}
