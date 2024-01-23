using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesWebApp.Business.DTOs.EpisodeDTOs;
using MoviesWebApp.Business.Exceptions.EpisodeModelException;
using MoviesWebApp.Business.Exceptions.FormatExceptions;
using MoviesWebApp.Business.Services.Implementations;
using MoviesWebApp.Business.Services.Interfaces;


using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminEpisode
{
    public class UpdateModel : PageModel
    {
        private readonly IEpisodeService _service;
        private readonly IMapper _mapper;
        private readonly IGenreService _genreService;
        private readonly ICountryService _countryService;
        private readonly ISerialService _serialService;
        private readonly ISeasonService _seasonService;

        [BindProperty]
        public EpisodeUpdateDto Episode { get; set; } = default!;
        public SelectList GenreList { get; set; }
        public SelectList Countries { get; set; }
        public SelectList Seasons { get; set; }
        public SelectList Serials { get; set; }


        public UpdateModel(IEpisodeService service,
            IMapper mapper, IGenreService genreService,
            ICountryService countryService,
            ISerialService serialService, ISeasonService seasonService)
        {
            this._service = service;
            this._mapper = mapper;
            this._genreService = genreService;
            this._countryService = countryService;
            this._serialService = serialService;
            this._seasonService = seasonService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
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

            var episode = await _service.GetById(id);
            if (episode is null) return NotFound();
            Episode = _mapper.Map<EpisodeUpdateDto>(episode);

            List<Genre> genres = _genreService.GetAll(g => g.IsDeleted == false).Result.ToList();
            if (genres != null)
            {
                GenreList = new SelectList(genres, "Id", "Name");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
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
                await _service.UpdateAsync( Episode);
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
