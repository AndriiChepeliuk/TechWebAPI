using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _context.Set<TEntity>().Add(entity);
            });
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() =>
            {
                _context.Set<TEntity>().AddRange(entities);
            });
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.Run(() => _context.Set<TEntity>().Where(expression));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => _context.Set<TEntity>().ToList());
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _context.Set<TEntity>().RemoveRange(entities));
        }
    }
}
