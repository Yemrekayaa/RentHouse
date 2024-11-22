using Microsoft.EntityFrameworkCore;
using RentHouse.Application.Interfaces;
using RentHouse.Persistence.Context;
using System.Linq.Expressions;

namespace RentHouse.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RentHouseContext _context;
        private DbSet<T> _dbSet;

        public Repository(RentHouseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FindAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbSet.CountAsync();
        }

    }
}
