using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;

namespace MoviesWebApp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly MoviesWebAppContext _context;

        public DetailsModel(MoviesWebAppContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;
        public About LogoPageInfo { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie= await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            var logoInfo = await _context.Abouts.FirstOrDefaultAsync(m => m.Id== id);
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
