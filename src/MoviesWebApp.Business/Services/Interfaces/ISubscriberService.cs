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
    public interface ISubscriberService
    {
        Task Delete(int id);
        Task<Subscriber> GetById(int? id);
        Task<Subscriber> Get(Expression<Func<Subscriber, bool>>? predicate, params string[]? includes);
        Task<IEnumerable<Subscriber>> GetAll(Expression<Func<Subscriber, bool>>? predicate, params string[]? includes);
    }
}
