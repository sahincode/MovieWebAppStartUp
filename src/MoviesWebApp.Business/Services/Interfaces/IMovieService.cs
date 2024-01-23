using MoviesWebApp.Business.DTOs.MovieDTOs;

using MoviesWebApp.Core.Models;
using System.Linq.Expressions;

namespace MoviesWebApp.Business.Services.Interfaces
{
    public  interface IMovieService
    {
        Task CreateAsync(MovieCreateDto entity);
        Task UpdateAsync(MovieUpdateDto entity);
        Task Delete (int id);
        Task SoftDelete(int id);
        Task< Movie > GetById(int id);
        Task<Movie> Get(Expression<Func<Movie, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<Movie>> GetAll(Expression<Func<Movie, bool>>? predicate, params string[] ? includes);
    }
}
