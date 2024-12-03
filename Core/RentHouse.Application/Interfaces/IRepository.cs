using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Common.Sort;
using System.Linq.Expressions;

namespace RentHouse.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(PaginationQuery paginationQuery, SortingQuery sortingQuery, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> filter);
        Task<int> GetCountAsync();
        Task<List<T>> Where(Expression<Func<T, bool>> predicate);

    }
}
