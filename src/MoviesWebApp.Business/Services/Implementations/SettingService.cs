using AutoMapper;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Business.DTOs.SettingDTOs;
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
    public class SettingService : ISettingService
    {
        private readonly IMapper _mapper;
        private readonly ISettingRepository _setting;

        public SettingService(IMapper mapper, ISettingRepository setting)
        {
            this._mapper = mapper;

            this._setting = setting;

        }
        public async Task UpdateAsync(SettingUpdateDto entity)
        {
            Setting setting = await this.GetById(entity.Id);
            if (setting is null) throw new NullEntityException("", "the setting does not exist in database");
            setting = _mapper.Map(entity, setting);
            await _setting.CommitChange();


        }



        public async Task Delete(int id)
        {
            var about = await _setting.Get(a => a.Id == id);
            if (about == null) throw new EntityNotFoundException($"The entity with the ID equal to {id} was not found in the database.");
            _setting.Delete(about);
        }

        public async Task<Setting> Get(Expression<Func<Setting, bool>>? predicate, params string[]? includes)
        {
            return await _setting.Get(predicate, includes) is not null ?
                 await _setting.Get(predicate, includes) :
                 throw new EntityNotFoundException($"The entity with the ID equal to " +
                 $"{predicate} was not found in the database.");
        }



        public async Task<IEnumerable<Setting>> GetAll(Expression<Func<Setting, bool>>? predicate, params string[]? includes)
        {
            return await _setting.GetAll(predicate, includes) is not null ?
                await _setting.GetAll(predicate, includes) :
                throw new EntityNotFoundException($"The entity with the ID equal to" +
                $" {predicate} was not found in the database.");
        }



        public async Task<Setting> GetById(int? id)
        {
            return await _setting.Get(a => a.Id == id);
        }


    }
}
