using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;

namespace MoviesWebApp.Models.LogoinfoModel
{
    public class IndexModel : PageModel
    {
        private readonly MoviesWebApp.Data.MoviesWebAppContext _context;

        public IndexModel(MoviesWebApp.Data.MoviesWebAppContext context)
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
