using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.DTOs.EpisodeDTOs;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using MoviesWebApp.ViewModels;

namespace MoviesWebApp.Pages.Series
{
    public class SerialDetailModel : PageModel
    {
        private readonly IEpisodeService _episodeService;
        private readonly IMapper _mapper;
        private readonly IEpisodeGenreRepository _episodeGenreRepository;
        private readonly ISerialService _serialService;

        public List<EpisodeIndexDto> EpisodeIndexDtos { get; set; }
        public SerialDetailModel(IEpisodeService episodeService,
            IMapper mapper, IEpisodeGenreRepository episodeGenreRepository, ISerialService serialService)
        {
            this._episodeService = episodeService;
            this._mapper = mapper;
            this._episodeGenreRepository = episodeGenreRepository;
            this._serialService = serialService;
        }
        public async Task<IActionResult> OnGet(int? id)
        {

            if (id is null) return NotFound();
            List<Episode> episodes = _episodeService.GetAll(e => e.IsDeleted == false, "Season", "EpisodeGenres").Result.ToList();
            List<EpisodeIndexDto> episodeIndexDtos = new List<EpisodeIndexDto>();
            foreach (Episode episode in episodes)
            {
                EpisodeIndexDto episodeIndexDto = _mapper.Map<EpisodeIndexDto>(episode);
                episodeIndexDto.EpisodeGenres = _episodeGenreRepository.Table.Where(g => g.EpisodeId == episode.Id).Include("Genre").ToList();
                episodeIndexDto.Season.Serial = await _serialService.GetById(episodeIndexDto.Season.SerialId);
                episodeIndexDtos.Add(episodeIndexDto);
            }
            EpisodeIndexDtos = episodeIndexDtos;

            return Page();
        }
    }
}
