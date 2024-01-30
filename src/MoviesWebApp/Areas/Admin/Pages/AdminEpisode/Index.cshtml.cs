using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.DTOs.EpisodeDTOs;
using MoviesWebApp.Business.Exceptions.AboutModelExceptions;
using MoviesWebApp.Business.Services.Implementations;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;

namespace MoviesWebApp.Areas.Admin.Pages.AdminEpisode
{
    public class IndexModel : PageModel
    {
        private readonly IEpisodeService _episodeService;
        private readonly IMapper _mapper;
        private readonly IEpisodeGenreRepository _episodeGenreRepository;

        public List<EpisodeIndexDto> Episodes { get; set; } = new List<EpisodeIndexDto>();

        public IndexModel(IEpisodeService episodeService, IMapper mapper,
             IEpisodeGenreRepository episodeGenreRepository)
        {
            this._episodeService = episodeService;
            this._mapper = mapper;
            this._episodeGenreRepository = episodeGenreRepository;
        }
        public async Task<IActionResult> OnGetAsync()
        {

            IEnumerable<Episode> movies = await _episodeService.GetAll(null, "EpisodeGenres");

            if (movies is null) return NotFound();
            foreach (Episode episode in movies)
            {

                EpisodeIndexDto episodeIndex = _mapper.Map<EpisodeIndexDto>(episode);
                episodeIndex.EpisodeGenres= _episodeGenreRepository.Table.Where(g=>g.EpisodeId==episode.Id).Include("Genre").ToList();
                Episodes.Add(episodeIndex);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDelete([FromBody] int id)
        {

            try
            {
                await _episodeService.Delete(id);
            }
            catch (NullIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostToggleDelete(int id)
        {

            try
            {
                await _episodeService.ToggleDelete(id);
            }
            catch (NullIdException ex)
            {
                return NotFound(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


            return RedirectToAction("OnGet");
        }
    }
}
