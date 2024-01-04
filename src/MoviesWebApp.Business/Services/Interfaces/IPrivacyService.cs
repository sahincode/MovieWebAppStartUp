using MoviesWebApp.Business.DTOs.PrivacyDTOs;
using MoviesWebApp.Core.Models;
using System.Linq.Expressions;

namespace MoviesWebApp.Business.Services.Interfaces
{
    public  interface IPrivacyService
    {
        Task CreateAsync(PrivacyCreateDto entity);
        Task UpdateAsync(int ? id ,PrivacyUpdateDto entity);
        Task Delete(int  id);
        Task ToggleDelete(int id);
        Task<Privacy> GetById(int? id);
        Task<Privacy> Get(Expression<Func<Privacy, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<Privacy>> GetAll(Expression<Func<Privacy, bool>>? predicate, params string[]? includes);
    }
}
