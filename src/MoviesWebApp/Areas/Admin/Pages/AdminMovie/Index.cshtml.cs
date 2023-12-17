using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Core.Models;

using MoviesWebApp.Data.DAL;


namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class IndexModel : PageModel
    {
        private readonly MoviesWebAppContext _context;

        public IndexModel(MoviesWebAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movies { get; set; } = default!;
        public LogoPageInfo LogoPageInfo { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Movies != null || _context.LogoPageInfo == null)
            {
                Movies = await _context.Movies.ToListAsync();
                LogoPageInfo = await _context.LogoPageInfo.FirstOrDefaultAsync();
            }
        }
    }
}
