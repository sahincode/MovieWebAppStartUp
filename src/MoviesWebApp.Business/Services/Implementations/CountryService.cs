using AutoMapper;
using MoviesWebApp.Business.DTOs.CountryDTOs;
using MoviesWebApp.Business.Exceptions;
using MoviesWebApp.Business.Exceptions.CountryModelExceptions;
using MoviesWebApp.Business.Exceptions.ReferenceExceptions;
using MoviesWebApp.Business.Services.Interfaces;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MoviesWebApp.Business.Services.Implementations;
public class CountryService : ICountryService
{
    private readonly IMapper _mapper;
    private readonly ICountryRepository _country;

    public CountryService(IMapper mapper, ICountryRepository country)
    {
        this._mapper = mapper;
        this._country = country;
    }
    public async Task CreateAsync(CountryCreateDto entity)
    {
        Country country = _mapper.Map<Country>(entity);
        await _country.CreateAsync(country);
        await _country.CommitChange();


    }

    public async Task Delete(int? id)
    {
        if (id == null)
        {
            throw new NullIdException("Id can not be null!");
        }
        var country = await _country.Get(a => a.Id == id);

        if (country == null) throw new CountryNotFoundException($" country with ID equal to {id} was not found in the database.");
        _country.Delete(country);
        await _country.CommitChange();


    }

    public async Task<Country> Get(Expression<Func<Country, bool>>? predicate, params string[]? includes)
    {
        return await _country.Get(predicate, includes) is not null ?
             await _country.Get(predicate, includes) :
             throw new EntityNotFoundException($"The entity with the ID equal to " +
             $"{predicate} was not found in the database.");
    }

    public async Task<IEnumerable<Country>> GetAll(Expression<Func<Country, bool>>? predicate, params string[]? includes)
    {
        return await _country.GetAll(predicate, includes) is not null ?
            await _country.GetAll(predicate, includes) :
            throw new EntityNotFoundException($"The entity with the ID equal to" +
            $" {predicate} was not found in the database.");
    }

    public async Task<Country> GetById(int? id)
    {
        return await _country.Get(a => a.Id == id);
    }



    public async Task ToggleDelete(int id)
    {
        var country = await this.GetById(id);
        if (country == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
            $"{id} was not found in the database.");
        country.IsDeleted = !country.IsDeleted;
        await _country.CommitChange();

    }

    public async Task UpdateAsync(int? id, CountryUpdateDto entity)
    {

        var updatedcountry = await _country.Get(a => a.Id == id);
        if (updatedcountry == null) throw new EntityNotFoundException($"The entity with the ID equal to " +
            $"{id} was not found in the database.");
        updatedcountry = _mapper.Map(entity, updatedcountry);

        await _country.CommitChange();

    }


}
