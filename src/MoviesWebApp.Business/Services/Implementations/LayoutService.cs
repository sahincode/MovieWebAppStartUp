using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Business.DTOs.SettingDTOs;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Implementations
{
    public class LayoutService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ISettingService _settingService;
        
        private readonly IMapper _mapper;

        public LayoutService(IGenreRepository genreRepository,
            ISettingService settingService,  IMapper mapper)
        {
            this._genreRepository = genreRepository;
            this._settingService = settingService;
            
            this._mapper = mapper;
        }

        public async Task<List<GenreLayoutDto>> GetGenres()
        {
            List<GenreLayoutDto> genres = await _genreRepository.Table.OrderBy(g => g.Name).Select(g => new GenreLayoutDto() { Id = g.Id, Name = g.Name }).ToListAsync();
            return genres;
        }
        public async Task<SettingLayoutDto> GetSetting()
        {
            Setting setting = await _settingService.Get(s => s.IsDeleted == false, null);
            SettingLayoutDto settingLayout = _mapper.Map<SettingLayoutDto>(setting);
            return settingLayout;
        }
       
    }
}
