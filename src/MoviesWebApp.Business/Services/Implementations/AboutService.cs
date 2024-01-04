using AutoMapper;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.InternalHelperServices;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Business.DTOs.AboutDTOs;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using System.Linq.Expressions;
namespace MoviesWebApp.Business.Services.Implementations
{
    public class AboutService : IAboutService
    {
        private readonly IMapper _mapper;
        private readonly IAboutRepository _about;

        public AboutService(IMapper mapper , IAboutRepository about)
        {
            this._mapper = mapper;
            this._about = about;
        }
        public  async Task CreateAsync(AboutCreateDto entity)
        {
            About about =_mapper.Map<About>(entity);
            await  _about.CreateAsync(about);
           await   _about.CommitChange();

         
        }

        public async Task Delete(int id)
        {
            var about = await _about.Get(a => a.Id == id);
            if (about == null) throw new EntityNotFoundException($"The entity with the ID equal to {id} was not found in the database.");
              _about.Delete(about);

          
        }

        public async Task<About> Get(Expression<Func<About, bool>>? predicate, params string[]? includes)
        {
           return  await _about.Get(predicate, includes) is not null? 
                await _about.Get(predicate, includes) : 
                throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{predicate} was not found in the database."); 
        }

        public async  Task<IEnumerable<About>> GetAll(Expression<Func<About, bool>>? predicate, params string[]? includes)
        {
            return await _about.GetAll(predicate, includes) is not null ?
                await _about.GetAll(predicate, includes) : 
                throw new EntityNotFoundException($"The entity with the ID equal to" +
                $" {predicate} was not found in the database.");
        }

        public async Task<About> GetById(int? id)
        {
          return    await _about.Get(a => a.Id == id);
        }

       

        public async  Task ToggleDelete(int id)
        {
            var about =  await this.GetById(id);
            if (about == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            _about.Delete(about);
            await  _about.CommitChange();

        }

        public async  Task UpdateAsync(int?  id ,AboutUpdateDto entity)
        {
            
            var updatedAbout = await  _about.Get(a => a.Id == id);
            if (updatedAbout == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            updatedAbout=_mapper.Map(entity, updatedAbout);
           
            await  _about.CommitChange();

        }

        
    }
}
