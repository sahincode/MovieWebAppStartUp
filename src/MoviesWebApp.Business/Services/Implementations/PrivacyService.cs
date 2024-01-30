using AutoMapper;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.InternalHelperServices;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using System.Linq.Expressions;
using MoviesWebApp.Business.DTOs.PrivacyDTOs;

namespace MoviesWebApp.Business.Services.Implementations
{
    public class PrivacyService : IPrivacyService
    {
        private readonly IMapper _mapper;
        private readonly IPrivacyRepository _privacy;

        public PrivacyService(IMapper mapper , IPrivacyRepository privacyRepository)
        {
            this._mapper = mapper;
            this._privacy = privacyRepository;
        }
        public  async Task CreateAsync(PrivacyCreateDto entity)
        {
            Privacy privacy =_mapper.Map<Privacy>(entity);
            await  _privacy.CreateAsync(privacy);
           await   _privacy.CommitChange();

         
        }

        public async Task Delete(int id)
        {
            var privacy = await _privacy.Get(a => a.Id == id);
            if (privacy == null) throw new EntityNotFoundException($"The entity with the ID equal to {id} was not found in the database.");
              _privacy.Delete(privacy);

          
        }

        public async Task<Privacy> Get(Expression<Func<Privacy, bool>>? predicate, params string[]? includes)
        {
           return  await _privacy.Get(predicate, includes) is not null? 
                await _privacy.Get(predicate, includes) : 
                throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{predicate} was not found in the database."); 
        }

        public async  Task<IEnumerable<Privacy>> GetAll(Expression<Func<Privacy, bool>>? predicate, params string[]? includes)
        {
            return await _privacy.GetAll(predicate, includes) is not null ?
                await _privacy.GetAll(predicate, includes) : 
                throw new EntityNotFoundException($"The entity with the ID equal to" +
                $" {predicate} was not found in the database.");
        }

        public async Task<Privacy> GetById(int? id)
        {
          return    await _privacy.Get(a => a.Id == id);
        }

       

        public async  Task ToggleDelete(int id)
        {
            var privacy =  await this.GetById(id);
            if (privacy == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            privacy.IsDeleted = !privacy.IsDeleted;
            await  _privacy.CommitChange();

        }

        public async  Task UpdateAsync(int?  id ,PrivacyUpdateDto entity)
        {
            
            var updatedPrivacy = await  _privacy.Get(a => a.Id == id);
            if (updatedPrivacy == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            updatedPrivacy = _mapper.Map(entity, updatedPrivacy);
           
            await  _privacy.CommitChange();

        }

        
    }
}
