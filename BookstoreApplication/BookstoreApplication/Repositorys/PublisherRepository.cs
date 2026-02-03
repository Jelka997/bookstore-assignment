using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositorys
{
    public class PublisherRepository : IPublisherRepository
    {
        private AppDbContext _context;

        public PublisherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Publisher> AddAsync(Publisher publisher)
        {
            _context.Publisher.Add(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        public async Task<Publisher> UpdateAsync(Publisher publisher)
        {
            _context.Publisher.Update(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Publisher publisher = await _context.Publisher.FindAsync(id);
            if (publisher == null)
            {
                return false;
            }

            _context.Publisher.Remove(publisher);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Publisher>> GetAllAsync(string order, string orderDirection)
        {
            IQueryable<Publisher> query = _context.Publisher;

            if (order == "Name")
            {
               query = orderDirection == "ASC" ? query.OrderBy(n => n.Name) : query.OrderByDescending(n => n.Name);

            }
            else if(order == "Address")
            {
                query = orderDirection == "ASC" ? query.OrderBy(n => n.Address) : query.OrderByDescending(n => n.Address);
            }

            return await query.ToListAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _context.Publisher.FindAsync(id);
        }
    }
}
