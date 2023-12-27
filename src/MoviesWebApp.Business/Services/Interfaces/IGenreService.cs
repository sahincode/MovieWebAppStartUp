using MoviesWebApp.Core.DTOs.GenreDTOs;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Interfaces
{
    public  interface IGenreService
    {
        Task CreateAsync(GenreCreateDto entity);
        Task UpdateAsync(int? id, GenreUpdateDto entity);
        Task Delete(int id);
        Task ToggleDelete(int id);
        Task<Genre> GetById(int? id);
        Task<Genre> Get(Expression<Func<Genre, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<Genre>> GetAll(Expression<Func<Genre, bool>>? predicate, params string[]? includes);
    }
}
