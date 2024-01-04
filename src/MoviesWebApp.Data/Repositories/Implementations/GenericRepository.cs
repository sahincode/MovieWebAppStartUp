using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Core.Models;
using MoviesWebApp.Core.Repositories.Interfaces;
using MoviesWebApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWebApp.Data.Repositories.Implementations
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly MoviesWebAppContext _context;
        public GenericRepository(MoviesWebAppContext context)
        {
            this._context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();
        public async Task<int> CommitChange()
        {
           return   await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public async  Task<TEntity> Get(Expression<Func<TEntity, bool>>? predicate, params string[]? includes)
        {
            var query = GetQuery(includes);
            query = GetQueryWithExpression(query, predicate);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate, params string[]? includes)
        { var query = GetQuery(includes);
            query=GetQueryWithExpression(query ,predicate);
            return await query.ToListAsync();
        }
        private IQueryable<TEntity>GetQuery(string[] includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
        private IQueryable<TEntity> GetQueryWithExpression(  IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null) query = query.Where(predicate);
            return query;

        }
    }
}
