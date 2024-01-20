using MoviesWebApp.Business.DTOs.SeasonDTOs;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Core.Models;
using System.Linq.Expressions;

namespace MoviesWebApp.Business.Services.Interfaces;
public interface ISeasonService
{
    Task CreateAsync(SeasonCreateDto entity);
    Task UpdateAsync(int? id, SeasonUpdateDto entity);
    Task Delete(int id);
    Task ToggleDelete(int id);
    Task<Season> GetById(int? id);
    Task<Season> Get(Expression<Func<Season, bool>>? predicate, params string[]? includes);
    Task<IEnumerable<Season>> GetAll(Expression<Func<Season, bool>>? predicate, params string[]? includes);
}
