using MoviesWebApp.Business.DTOs.AboutDTOs;
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
    public  interface IAboutService
    {
        Task CreateAsync(AboutCreateDto entity);
        Task UpdateAsync(int ? id ,AboutUpdateDto entity);
        Task Delete(int? id);
        Task ToggleDelete(int id);
        Task<About> GetById(int? id);
        Task<About> Get(Expression<Func<About, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<About>> GetAll(Expression<Func<About, bool>>? predicate, params string[]? includes);
    }
}
