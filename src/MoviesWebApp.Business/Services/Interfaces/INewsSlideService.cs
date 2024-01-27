using MoviesWebApp.Business.DTOs.NewsSlideDTOs;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Interfaces
{
    public interface INewsSlideService
    {
        Task CreateAsync(NewsSlideCreateDto entity);
        Task UpdateAsync(NewsSlideUpdateDto entity);
        Task Delete(int id);
        Task ToggleDelete(int id);
        Task<NewsSlide> GetById(int? id);
        Task<NewsSlide> Get(Expression<Func<NewsSlide, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<NewsSlide>> GetAll(Expression<Func<NewsSlide, bool>>? predicate, params string[]? include);
    }
}
