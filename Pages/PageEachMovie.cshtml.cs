using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;
using MoviesWebApp.Models.DTO;
using MoviesWebApp.Pages.moviefolder;

namespace MoviesWebApp.Pages
{
     public class PageEachMovieModel : PageModel
    {
        private readonly MoviesWebAppContext _context;

        public PageEachMovieModel(MoviesWebAppContext context)
        {
            _context = context;
        }

        public Movies Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie= await _context.Movies.FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
