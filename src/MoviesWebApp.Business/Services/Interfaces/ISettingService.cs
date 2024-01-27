using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Business.DTOs.SettingDTOs;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Interfaces
{
    public  interface ISettingService
    {
        //Task CreateAsync(SettingUpdateDto entity);
        Task UpdateAsync( SettingUpdateDto entity);
        Task Delete(int id);
        //Task ToggleDelete(int id);
        Task<Setting> GetById(int? id);
        Task<Setting> Get(Expression<Func<Setting, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<Setting>> GetAll(Expression<Func<Setting, bool>>? predicate, params string[]? includes);
    }
}
