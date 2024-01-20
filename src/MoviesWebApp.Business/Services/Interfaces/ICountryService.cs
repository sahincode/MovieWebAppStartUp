using MoviesWebApp.Business.DTOs.CountryDTOs;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Interfaces
{
    public interface ICountryService
    {
        Task CreateAsync(CountryCreateDto entity);
        Task UpdateAsync(int? id, CountryUpdateDto entity);
        Task Delete(int? id);
        Task ToggleDelete(int id);
        Task<Country> GetById(int? id);
        Task<Country> Get(Expression<Func<Country, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<Country>> GetAll(Expression<Func<Country, bool>>? predicate, params string[]? includes);
    }
}
