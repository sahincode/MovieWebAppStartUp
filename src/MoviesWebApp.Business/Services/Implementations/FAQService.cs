using AutoMapper;
using MoviesWebApp.Business.DTOs.FAQDTOs;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MoviesWebApp.Business.Services.Implementations
{
    public class FAQService :IFAQService
    {
        private readonly IMapper _mapper;
        private readonly IFAQRepository _faqRepository;

        public FAQService(IMapper mapper, IFAQRepository faqRepository)
        {
            this._mapper = mapper;
            this._faqRepository = faqRepository;
        }
        public async Task CreateAsync(FAQCreateDto entity)
        {
            FAQ slide = _mapper.Map<FAQ>(entity);
            await _faqRepository.CreateAsync(slide);
            await _faqRepository.CommitChange();


        }

     

        public async Task Delete(int id)
        {
            FAQ faq = await _faqRepository.Get(a => a.Id == id);
            if (faq == null) throw new EntityNotFoundException($"The entity with the ID equal to {id} was not found in the database.");
            _faqRepository.Delete(faq);
            await  _faqRepository.CommitChange();


        }

        public async Task<FAQ> Get(Expression<Func<FAQ, bool>>? predicate, params string[]? includes)
        {
            return await _faqRepository.Get(predicate, includes) is not null ?
                 await _faqRepository.Get(predicate, includes) :
                 throw new EntityNotFoundException($"The entity with the ID equal to " +
                 $"{predicate} was not found in the database.");
        }

        public async Task<IEnumerable<FAQ>> GetAll(Expression<Func<FAQ, bool>>? predicate, params string[]? includes)
        {
            return await _faqRepository.GetAll(predicate, includes) is not null ?
                await _faqRepository.GetAll(predicate, includes) :
                throw new EntityNotFoundException($"The entity with the ID equal to" +
                $" {predicate} was not found in the database.");
        }

        public async Task<FAQ> GetById(int? id)
        {
            return await _faqRepository.Get(a => a.Id == id);
        }



        public async Task ToggleDelete(int id)
        {
            var faq = await this.GetById(id);
            if (faq == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            faq.IsDeleted = !faq.IsDeleted;
            await _faqRepository.CommitChange();

        }

        public async Task UpdateAsync(FAQUpdateDto entity)
        {

            var updatedFAQ = await _faqRepository.Get(a => a.Id == entity.Id);
            if (updatedFAQ == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{entity.Id} was not found in the database.");
            updatedFAQ = _mapper.Map(entity, updatedFAQ);

            await _faqRepository.CommitChange();

        }
    }
}
