using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Data;
using MoviesWebApp.Models;

namespace MoviesWebApp.Pages
{
    public class AdminPageModel : PageModel
    {
        private readonly MoviesWebAppContext _context;

        public AdminPageModel(MoviesWebAppContext context)
        {
            _context = context;
        }

        public IList<Movies> Movies { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movies != null)
            {
                Movies = await _context.Movies.ToListAsync();
            }
        }
    }
}
