using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.Exceptions.FormatExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Data.DAL;

using NuGet.ProjectModel;
using MoviesWebApp.Business.Services.Implementations;

namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{ 
    public class CreateModel : PageModel
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly ICountryService _countryService;

        [BindProperty]
        public MovieCreateDto Movie { get; set; }
        public SelectList GenreList { get; set; }
        public SelectList Countries { get; set; }

        public CreateModel(IMovieService movieService, IGenreService genreService ,ICountryService countryService)
        {
            this._movieService = movieService;
            this._genreService = genreService;
            this._countryService = countryService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var countries = await _countryService.GetAll(null, null);
            if (countries != null)
            {
                Countries = new SelectList(countries, "Name", "Name");
            }
            var claims = User.Claims;

            List<Genre> genres = _genreService.GetAll(g => g.IsDeleted == false).Result.ToList();
            if (genres != null)
            {
                GenreList = new SelectList(genres, "Id", "Name");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var countries = await _countryService.GetAll(null, null);
            if (countries != null)
            {
                Countries = new SelectList(countries, "Name", "Name");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _movieService.CreateAsync(Movie);

            }
            catch (MovieFileFormatException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return Page();
            }


            return RedirectToPage("./Index");
        }
    }
}
