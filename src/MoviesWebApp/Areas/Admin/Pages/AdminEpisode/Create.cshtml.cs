using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.DTOs.EpisodeDTOs;
using MoviesWebApp.Business.Exceptions.EpisodeModelException;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace episodesWebApp.Areas.Admin.Pages.AdminEpisode
{
    public class CreateModel : PageModel
    {
        private readonly IEpisodeService _episodeService;
        private readonly IGenreService _genreService;
        private readonly ICountryService _countryService;
        private readonly ISeasonService _seasonService;
        private readonly ISerialService _serialService;

        [BindProperty]
        public EpisodeCreateDto Episode { get; set; }
        public SelectList GenreList { get; set; }
        public SelectList Countries { get; set; }
        public SelectList Seasons { get; set; }
        public SelectList Serials { get; set; }



        public CreateModel(IEpisodeService episodeService,
            IGenreService genreService,
            ICountryService countryService,
            ISeasonService seasonService, ISerialService serialService)
        {
            this._episodeService = episodeService;
            this._genreService = genreService;
            this._countryService = countryService;
            this._seasonService = seasonService;
            this._serialService = serialService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var countries = await _countryService.GetAll(null, null);
            if (countries != null)
            {
                Countries = new SelectList(countries, "Name", "Name");
            }
            var serials = await _serialService.GetAll(null, null);
            if (serials != null)
            {
                Serials = new SelectList(serials, "Id", "Name");
            }
            var seasons = await _seasonService.GetAll(null, null);
            if (seasons != null)
            {
                Seasons = new SelectList(seasons, "Id", "Name");
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
            List<Genre> genres = _genreService.GetAll(null, null).Result.ToList();
            if (genres != null)
            {
                GenreList = new SelectList(genres, "Id", "Name");
            }
            var countries = await _countryService.GetAll(null, null);
            if (countries != null)
            {
                Countries = new SelectList(countries, "Name", "Name");
            }
            var seasons = await _seasonService.GetAll(null, null);
            if (seasons != null)
            {
                Seasons = new SelectList(seasons, "Id", "Name");
            }
            var serials = await _serialService.GetAll(null, null);
            if (serials != null)
            {
                Serials = new SelectList(serials, "Id", "Name");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _episodeService.CreateAsync(Episode);

            }
            catch (EpisodeFileFormatException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return Page();
            }


            return RedirectToPage("./Index");
        }
    }
}
