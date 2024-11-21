using Microsoft.EntityFrameworkCore;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;
using RentHouse.Persistence.Context;

namespace RentHouse.Persistence.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly RentHouseContext _context;

        public BlogRepository(RentHouseContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetBlogsWithAuthorAsync(int? count = null)
        {
            var values = _context.Blogs.Include(x => x.Author).AsQueryable();
            if (count.HasValue)
            {
                values = values.OrderByDescending(x => x.BlogID).Take(count.Value);
            }
            return await values.ToListAsync();
        }

    }
}
