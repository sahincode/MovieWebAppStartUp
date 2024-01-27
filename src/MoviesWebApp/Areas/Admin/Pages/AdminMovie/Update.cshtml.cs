using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.DTOs.MovieDTOs;
using MoviesWebApp.Business.Exceptions.FormatExceptions;
using MoviesWebApp.Business.Services.Implementations;
using MoviesWebApp.Business.Services.Interfaces;


using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminMovie
{
    public class UpdateModel : PageModel
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;
        private readonly IGenreService _genreService;
        private readonly ICountryService _countryService;

        [BindProperty]
        public MovieUpdateDto Movie { get; set; } = default!;
        public SelectList GenreList { get; set; }
        public SelectList Countries { get; set; }

        public UpdateModel(IMovieService service,
            IMapper mapper, IGenreService genreService,
            ICountryService countryService)
        {
            this._service = service;
            this._mapper = mapper;
            this._genreService = genreService;
            this._countryService = countryService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var countries = await _countryService.GetAll(null, null);
            if (countries != null)
            {
                Countries = new SelectList(countries, "Name", "Name");
            }
            var movie = await _service.Get(m => m.Id == id, "MovieGenres");
            if (movie is null) return NotFound();
            Movie = _mapper.Map<MovieUpdateDto>(movie);
            Movie.GenreIds = movie.MovieGenres.Select(g => g.GenreId).ToList();
            List<Genre> genres = _genreService.GetAll(g => g.IsDeleted == false).Result.ToList();
            if (genres != null)
            {
                GenreList = new SelectList(genres, "Id", "Name");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var countries = await _countryService.GetAll(null, null);
            if (countries != null)
            {
                Countries = new SelectList(countries, "Name", "Name");
            }
            List<Genre> genres = _genreService.GetAll(g => g.IsDeleted == false).Result.ToList();
            if (genres != null)
            {
                GenreList = new SelectList(genres, "Id", "Name");
            }

            if (!ModelState.IsValid || id == null)
            {
                return Page();
            }

            try
            {
                Movie.Id = id;
                await _service.UpdateAsync(Movie);
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
