using MoviesWebApp.Business.DTOs.MovieDTOs;

using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Interfaces
{
    public  interface IMovieService
    {
        Task CreateAsync(MovieCreateDto entity);
        Task UpdateAsync(int id ,MovieUpdateDto entity);
        Task Delete (MovieDeleteDto movie);
        Task SoftDelete(int id);
        Task< Movie > GetById(int id);
        Task<Movie> Get(Expression<Func<Movie, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<Movie>> GetAll(Expression<Func<Movie, bool>>? predicate, params string[] ? includes);
    }
}
