using Microsoft.EntityFrameworkCore;
using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Common.Sort;
using RentHouse.Application.Interfaces;
using RentHouse.Persistence.Context;
using System.Linq.Dynamic.Core;
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

		public async Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> filter)
		{
			return await _dbSet.Where(filter).ToListAsync();
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

		public async Task<List<T>> Where(Expression<Func<T, bool>> predicate)
		{
			return await _dbSet.Where(predicate).ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync(PaginationQuery paginationQuery, SortingQuery sortingQuery, CancellationToken cancellationToken)
		{
			var query = _dbSet.AsQueryable();



			if (!string.IsNullOrEmpty(sortingQuery.OrderBy))
			{
				var sortExpression = $"{sortingQuery.OrderBy} {(sortingQuery.IsDescending ? "descending" : "ascending")}";
				query = query.OrderBy(sortExpression); // Dynamic LINQ
			}
			query = query.Skip((paginationQuery.PageNumber - 1) * paginationQuery.PageSize).Take(paginationQuery.PageSize);
			return await query.ToListAsync(cancellationToken);

		}


	}
}
