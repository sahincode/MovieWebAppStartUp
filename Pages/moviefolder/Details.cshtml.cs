using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Pages.moviefolder
{
    public class DetailsModel : PageModel
    {
        private readonly MoviesWebAppContext _context;

        public DetailsModel(MoviesWebAppContext context)
        {
            _context = context;
        }

        public Movies Movies { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies.FirstOrDefaultAsync(m => m.ID == id);
            if (movies == null)
            {
                return NotFound();
            }
            else
            {
                Movies = movies;
            }
            return Page();
        }
    }
}
