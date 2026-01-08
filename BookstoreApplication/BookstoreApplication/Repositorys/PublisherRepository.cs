using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositorys
{
    public class PublisherRepository
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

        public async Task<List<Publisher>> GetAllAsync()
        {
            Task<List<Publisher>> publishers = _context.Publisher.ToListAsync();
            List<Publisher> result = await publishers;
            return result;
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _context.Publisher.FindAsync(id);
        }
    }
}
