using AutoMapper;
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
    public class SubscriberService : ISubscriberService
    {
        private readonly IMapper _mapper;
        private readonly ISubscriberRepository _subscriber;

        public SubscriberService(IMapper mapper, ISubscriberRepository subscriberRepository)
        {
            this._mapper = mapper;

            this._subscriber = subscriberRepository;

        }
        public async Task Delete(int id)
        {
            var about = await _subscriber.Get(a => a.Id == id);
            if (about == null) throw new EntityNotFoundException($"The entity with the ID equal to {id} was not found in the database.");
            _subscriber.Delete(about);
        }

        public async Task<Subscriber> Get(Expression<Func<Subscriber, bool>>? predicate, params string[]? includes)
        {
            return await _subscriber.Get(predicate, includes) is not null ?
                 await _subscriber.Get(predicate, includes) :
                 throw new EntityNotFoundException($"The entity with the ID equal to " +
                 $"{predicate} was not found in the database.");
        }



        public async Task<IEnumerable<Subscriber>> GetAll(Expression<Func<Subscriber, bool>>? predicate, params string[]? includes)
        {
            return await _subscriber.GetAll(predicate, includes) is not null ?
                await _subscriber.GetAll(predicate, includes) :
                throw new EntityNotFoundException($"The entity with the ID equal to" +
                $" {predicate} was not found in the database.");
        }



        public async Task<Subscriber> GetById(int? id)
        {
            return await _subscriber.Get(a => a.Id == id);
        }
        public async Task ToggleDelete(int id)
        {
            var subscriber = await this.GetById(id);
            if (subscriber == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            subscriber.IsDeleted=!subscriber.IsDeleted;
            await _subscriber.CommitChange();

        }
    }
}
