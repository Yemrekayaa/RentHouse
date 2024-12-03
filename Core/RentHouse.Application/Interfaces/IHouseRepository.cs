using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Common.Sort;
using RentHouse.Domain.Entities;
using System.Linq.Expressions;

namespace RentHouse.Application.Interfaces
{
    public interface IHouseRepository
    {
        Task<List<House>> GetHouseListWithLocationAsync(int? count = null);
        Task<House> GetHouseWithLocationAsync(int id);
        Task<IEnumerable<House>> GetFilteredWithLocationAsync(Expression<Func<House, bool>> filter);
        Task<IEnumerable<House>> GetAvailableHousesAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<House>> GetAvailableHousesWithLocationAsync(DateTime startDate, DateTime endDate, PaginationQuery paginationQuery, SortingQuery sortingQuery);
        Task<int> GetAvailableHousesWithLocationCountAsync(DateTime startDate, DateTime endDate);
        Task<House> GetHouseWithFeaturesByIdAsync(int id);
        Task<int> CreateAsync(House house);
        Task<int> UpdateAsync(House house);
    }

}
