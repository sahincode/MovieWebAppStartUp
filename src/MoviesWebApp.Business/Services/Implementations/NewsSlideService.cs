using AutoMapper;
using MoviesWebApp.Business.DTOs.NewsSlideDTOs;
using MoviesWebApp.Business.DTOs.SerialDTOs;
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
    public class NewsSlideService : INewsSlideService
    {
        private readonly IMapper _mapper;
        private readonly INewsSlideRepository _newsSlide;

        public NewsSlideService(IMapper mapper, INewsSlideRepository newsSlide)
        {
            this._mapper = mapper;
            this._newsSlide = newsSlide;
        }
        public async Task CreateAsync(NewsSlideCreateDto entity)
        {
            NewsSlide slide = _mapper.Map<NewsSlide>(entity);
            await _newsSlide.CreateAsync(slide);
            await _newsSlide.CommitChange();


        }

   
        public async Task Delete(int id)
        {
            NewsSlide slide = await _newsSlide.Get(a => a.Id == id);
            if (slide == null) throw new EntityNotFoundException($"The entity with the ID equal to {id} was not found in the database.");
            _newsSlide.Delete(slide);
            _newsSlide.CommitChange();


        }

        public async Task<NewsSlide> Get(Expression<Func<NewsSlide, bool>>? predicate, params string[]? includes)
        {
            return await _newsSlide.Get(predicate, includes) is not null ?
                 await _newsSlide.Get(predicate, includes) :
                 throw new EntityNotFoundException($"The entity with the ID equal to " +
                 $"{predicate} was not found in the database.");
        }

        public async Task<IEnumerable<NewsSlide>> GetAll(Expression<Func<NewsSlide, bool>>? predicate, params string[]? includes)
        {
            return await _newsSlide.GetAll(predicate, includes) is not null ?
                await _newsSlide.GetAll(predicate, includes) :
                throw new EntityNotFoundException($"The entity with the ID equal to" +
                $" {predicate} was not found in the database.");
        }

        public async Task<NewsSlide> GetById(int? id)
        {
            return await _newsSlide.Get(a => a.Id == id);
        }



        public async Task ToggleDelete(int id)
        {
            var slide = await this.GetById(id);
            if (slide == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            slide.IsDeleted = !slide.IsDeleted;
            await _newsSlide.CommitChange();

        }

        public async Task UpdateAsync(NewsSlideUpdateDto entity)
        {

            var updatedSlide = await _newsSlide.Get(a => a.Id == entity.Id);
            if (updatedSlide == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{entity.Id} was not found in the database.");
            updatedSlide = _mapper.Map(entity, updatedSlide);

            await _newsSlide.CommitChange();

        }


    }
}
