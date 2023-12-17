using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;

namespace MoviesWebApp.Pages
{
    public class PageEachMovieModel : PageModel
    {
        private readonly MoviesWebAppContext _context;

        public PageEachMovieModel(MoviesWebAppContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;
        public LogoPageInfo LogoPageInfo { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie= await _context.Movies.FirstOrDefaultAsync(m => m.ID == id);
            var logoInfo = await _context.LogoPageInfo.FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
                LogoPageInfo = logoInfo;
            }
            return Page();
        }
    }
}
