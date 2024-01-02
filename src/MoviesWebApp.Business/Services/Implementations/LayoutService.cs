using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Core.DTOs.GenreDTOs;
using MoviesWebApp.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Implementations
{
    public  class LayoutService 
    {
        private readonly IGenreRepository _genreRepository;

        public LayoutService( IGenreRepository genreRepository)
        {
            this._genreRepository = genreRepository;
        }

        public async  Task <List<GenreLayoutDto>> GetGenres()
        {
            List<GenreLayoutDto> genres = await _genreRepository.Table.OrderBy(g => g.Name).Select(g=>new GenreLayoutDto() { Id=g.Id ,Name=g.Name}).ToListAsync();
            return genres;
        }
    }
}
