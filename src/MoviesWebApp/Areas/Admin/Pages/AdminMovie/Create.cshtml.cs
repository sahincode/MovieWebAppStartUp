using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.Exceptions.FormatExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;

using NuGet.ProjectModel;

namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class CreateModel : PageModel
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        [BindProperty]
        public Core.DTOs.MovieDTOs.MovieCreateDto Movie { get; set; }
        public SelectList GenreList { get; set; } 
        public CreateModel(IMovieService movieService ,IGenreService genreService)
        {
            this._movieService = movieService;
            this._genreService = genreService;
        }
        public async  Task<IActionResult> OnGetAsync()
        {
            var claims = User.Claims;

           List<Genre> genres  =_genreService.GetAll(g => g.IsDeleted == false).Result.ToList();
            if (genres != null)
            {
                GenreList = new SelectList(genres, "Id", "Name");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _movieService.CreateAsync(Movie);

            }catch(MovieFileFormatException ex) 
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return Page();
            }
            

            return RedirectToPage("./Index");
        }
    }
}
