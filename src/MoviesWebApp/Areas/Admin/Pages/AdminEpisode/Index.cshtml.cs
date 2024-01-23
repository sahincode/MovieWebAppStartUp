using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesWebApp.Business.DTOs.EpisodeDTOs;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;

namespace MoviesWebApp.Areas.Admin.Pages.AdminEpisode
{
    public class IndexModel : PageModel
    {
        private readonly IEpisodeService _episodeService;
        private readonly IMapper _mapper;

        public List<EpisodeIndexDto> Episodes { get; set; } = new List<EpisodeIndexDto>();

        public IndexModel(IEpisodeService episodeService, IMapper mapper)
        {
            this._episodeService = episodeService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            
            IEnumerable<Episode>movies  = await _episodeService.GetAll( null ,"EpisodeGenres");
            if(movies is null) return NotFound();
           foreach (Episode episode in movies)
            {
                EpisodeIndexDto episodeIndex = _mapper.Map<EpisodeIndexDto>(episode);
                Episodes.Add(episodeIndex);
            }
            return Page();
        }
    }
}
