using AutoMapper;
using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MoviesWebApp.Business.Services.Implementations
{
    public  class GenreService :IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genre;

        public GenreService(IMapper mapper, IGenreRepository genre)
        {
            this._mapper = mapper;
            this._genre = genre;
        }
        public async Task CreateAsync(GenreCreateDto entity)
        {
            Genre genre= _mapper.Map<Genre>(entity);
            await _genre.CreateAsync(genre);
            await _genre.CommitChange();


        }

        public async Task Delete(int id)
        {
            Genre genre = await _genre.Get(a => a.Id == id);
            if (genre == null) throw new EntityNotFoundException($"The entity with the ID equal to {id} was not found in the database.");
            _genre.Delete(genre);


        }

        public async Task<Genre> Get(Expression<Func<Genre, bool>>? predicate, params string[]? includes)
        {
            return await _genre.Get(predicate, includes) is not null ?
                 await _genre.Get(predicate, includes) :
                 throw new EntityNotFoundException($"The entity with the ID equal to " +
                 $"{predicate} was not found in the database.");
        }

        public async Task<IEnumerable<Genre>> GetAll(Expression<Func<Genre, bool>>? predicate, params string[]? includes)
        {
            return await _genre.GetAll(predicate, includes) is not null ?
                await _genre.GetAll(predicate, includes) :
                throw new EntityNotFoundException($"The entity with the ID equal to" +
                $" {predicate} was not found in the database.");
        }

        public async Task<Genre> GetById(int? id)
        {
            return await _genre.Get(a => a.Id == id);
        }



        public async Task ToggleDelete(int id)
        {
            var about = await this.GetById(id);
            if (about == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            about.IsDeleted = !about.IsDeleted;
            await _genre.CommitChange();

        }

        public async Task UpdateAsync(int? id, GenreUpdateDto entity)
        {

            var updatedGenre = await _genre.Get(a => a.Id == id);
            if (updatedGenre == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            updatedGenre = _mapper.Map(entity, updatedGenre);

            await _genre.CommitChange();

        }

        
    }
}
