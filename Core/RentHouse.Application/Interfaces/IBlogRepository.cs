using RentHouse.Domain.Entities;

namespace RentHouse.Application.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetBlogsWithAuthorAsync(int? count = null);
    }
}
