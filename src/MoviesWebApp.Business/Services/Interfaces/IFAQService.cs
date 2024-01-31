using MoviesWebApp.Business.DTOs.FAQDTOs;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Interfaces
{
    public interface IFAQService
    {
        Task CreateAsync(FAQCreateDto entity);
        Task UpdateAsync(FAQUpdateDto entity);
        Task Delete(int id);
        Task ToggleDelete(int id);
        Task<FAQ> GetById(int? id);
        Task<FAQ> Get(Expression<Func<FAQ, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<FAQ>> GetAll(Expression<Func<FAQ, bool>>? predicate, params string[]? include);
    }
}
