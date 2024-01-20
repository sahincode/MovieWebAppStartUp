using MoviesWebApp.Business.DTOs.GenreDTOs;
using MoviesWebApp.Business.DTOs.SerialDTOs;
using MoviesWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Business.Services.Interfaces
{
    public interface ISerialService
    {
        Task CreateAsync(SerialCreateDto entity);
        Task UpdateAsync(int? id, SerialUpdateDto entity);
        Task Delete(int id);
        Task ToggleDelete(int id);
        Task<Serial> GetById(int? id);
        Task<Serial> Get(Expression<Func<Serial, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<Serial>> GetAll(Expression<Func<Serial, bool>>? predicate, params string[]? includes);
    }
}
