using AutoMapper;
using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MoviesWebApp.Business.Services.Implementations
{
    public class SerialService : ISerialService
    {
        private readonly IMapper _mapper;
        private readonly ISerialRepository _serial;

        public SerialService(IMapper mapper, ISerialRepository serial)
        {
            this._mapper = mapper;
            this._serial = serial;
        }
        public async Task CreateAsync(SerialCreateDto entity)
        {
            Serial serial = _mapper.Map<Serial>(entity);
            await _serial.CreateAsync(serial);
            await _serial.CommitChange();


        }

        public async Task Delete(int id)
        {
            Serial genre = await _serial.Get(a => a.Id == id);
            if (genre == null) throw new EntityNotFoundException($"The entity with the ID equal to {id} was not found in the database.");
            _serial.Delete(genre);


        }

        public async Task<Serial> Get(Expression<Func<Serial, bool>>? predicate, params string[]? includes)
        {
            return await _serial.Get(predicate, includes) is not null ?
                 await _serial.Get(predicate, includes) :
                 throw new EntityNotFoundException($"The entity with the ID equal to " +
                 $"{predicate} was not found in the database.");
        }

        public async Task<IEnumerable<Serial>> GetAll(Expression<Func<Serial, bool>>? predicate, params string[]? includes)
        {
            return await _serial.GetAll(predicate, includes) is not null ?
                await _serial.GetAll(predicate, includes) :
                throw new EntityNotFoundException($"The entity with the ID equal to" +
                $" {predicate} was not found in the database.");
        }

        public async Task<Serial> GetById(int? id)
        {
            return await _serial.Get(a => a.Id == id);
        }



        public async Task ToggleDelete(int id)
        {
            var serial = await this.GetById(id);
            if (serial == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            _serial.Delete(serial);
            await _serial.CommitChange();

        }

        public async Task UpdateAsync(int? id, SerialUpdateDto entity)
        {

            var updatedSerial = await _serial.Get(a => a.Id == id);
            if (updatedSerial == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
                $"{id} was not found in the database.");
            updatedSerial = _mapper.Map(entity, updatedSerial);

            await _serial.CommitChange();

        }

        
    }
}
