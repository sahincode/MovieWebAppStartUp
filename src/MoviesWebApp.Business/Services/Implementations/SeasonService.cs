using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using MoviesWebApp.Business.DTOs.SeasonDTOs;
using MoviesWebApp.Business.Exceptions.FormatExceptions;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Exceptions.SizeExceptions;
using MoviesWebApp.Business.InternalHelperServices;
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
        private readonly IWebHostEnvironment _env;
        public const string passPath = "assets/uploads/season";

        public SeasonService(IMapper mapper, ISeasonRepository season, IWebHostEnvironment env)
        {
            this._mapper = mapper;
            this._season = season;
            this._env = env;
        }
        public async Task CreateAsync(SeasonCreateDto entity)
        {
            string rootPath = _env.WebRootPath;
            Season season = _mapper.Map<Season>(entity);
            if (entity.Image.ContentType != "image/jpeg" && entity.Image.ContentType != "image/png")
            {
                throw new ImageContentTypeException("Image", "only png or jpeg file!");
            }
            if (entity.Image.Length > 2097152)
            {
                throw new OutOfRangeImageSizeException("Image", "please upload less than 2 mg");
            }
            season.ImageUrl = await FileHelper.SaveImage(rootPath, passPath, entity.Image);
            await _season.CreateAsync(season);
            await _season.CommitChange();


        }

        public async Task Delete(int id)
        {
            string rootPath = _env.WebRootPath;
            Season season = await _season.Get(a => a.Id == id);
            if (season == null) throw new EntityNotFoundException($"The entity with the ID equal " +
                $"to {id} was not found in the database.");
            File.Delete(Path.Combine(rootPath, passPath, season.ImageUrl));
            _season.Delete(season);


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

        public async Task UpdateAsync(SeasonUpdateDto entity)
        {

            string rootPath = _env.WebRootPath;
            var updatedSeason = await _season.Get(a => a.Id == entity.Id);
            if (updatedSeason == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{entity.Id} was not found in the database.");
            updatedSeason = _mapper.Map(entity, updatedSeason);


            if (entity.Image is not null)
            {
                if (entity.Image.ContentType != "image/jpeg" && entity.Image.ContentType != "image/png")
                {
                    throw new ImageContentTypeException("Image", "only png or jpeg file!");
                }
                if (entity.Image.Length > 2097152)
                {
                    throw new OutOfRangeImageSizeException("Image", "please upload less than 2 mg");
                }
                updatedSeason.ImageUrl = await FileHelper.SaveImage(rootPath, passPath, entity.Image);
            }

            await _season.CommitChange();

        }


    }
}
