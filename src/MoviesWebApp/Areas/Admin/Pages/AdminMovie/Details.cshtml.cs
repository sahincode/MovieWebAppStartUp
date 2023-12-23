using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data;
using MoviesWebApp.Data.DAL;


namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class DetailsModel : PageModel
    {
        private readonly IMovieService _movieService;

        public DetailsModel( IMovieService movieService)
        {
            this._movieService = movieService;
        }
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
          var movie = await _movieService.GetById(id);
            if (movie == null) return NotFound();
            Movie = movie;
            return Page();
        }
    }
}
