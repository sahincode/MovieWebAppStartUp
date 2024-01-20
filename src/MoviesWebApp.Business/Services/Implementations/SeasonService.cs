using AutoMapper;
using MoviesWebApp.Business.DTOs.SeasonDTOs;

using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Implementations
{
    public class SeasonService : ISeasonService
    {
        private readonly IMapper _mapper;
        private readonly ISeasonRepository _season;

        public SeasonService(IMapper mapper, ISeasonRepository season)
        {
            this._mapper = mapper;
            this._season = season;
        }
        public async Task CreateAsync(SeasonCreateDto entity)
        {
            Season season = _mapper.Map<Season>(entity);
            await _season.CreateAsync(season);
            await _season.CommitChange();


        }

        public async Task Delete(int id)
        {
            Season genre = await _season.Get(a => a.Id == id);
            if (genre == null) throw new EntityNotFoundException($"The entity with the ID equal to {id} was not found in the database.");
            _season.Delete(genre);


        }

        public async Task<Season> Get(Expression<Func<Season, bool>>? predicate, params string[]? includes)
        {
            return await _season.Get(predicate, includes) is not null ?
                 await _season.Get(predicate, includes) :
                 throw new EntityNotFoundException($"The entity with the ID equal to " +
                 $"{predicate} was not found in the database.");
        }

        public async Task<IEnumerable<Season>> GetAll(Expression<Func<Season, bool>>? predicate, params string[]? includes)
        {
            return await _season.GetAll(predicate, includes) is not null ?
                await _season.GetAll(predicate, includes) :
                throw new EntityNotFoundException($"The entity with the ID equal to" +
                $" {predicate} was not found in the database.");
        }

        public async Task<Season> GetById(int? id)
        {
            return await _season.Get(a => a.Id == id);
        }



        public async Task ToggleDelete(int id)
        {
            var season = await this.GetById(id);
            if (season == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            _season.Delete(season);
            await _season.CommitChange();

        }

        public async Task UpdateAsync(int? id, SeasonUpdateDto entity)
        {

            var updatedSeason = await _season.Get(a => a.Id == id);
            if (updatedSeason == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            updatedSeason = _mapper.Map(entity, updatedSeason);

            await _season.CommitChange();

        }


    }
}
