using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositorys
{
    public class AuthorRepository
    {
        private AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Author> AddAsync(Author author)
        {
            _context.Author.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _context.Author.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Author author =await _context.Author.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            Task<List<Author>> dbTask = _context.Author.ToListAsync();
            List<Author> result = await dbTask;
            return result;
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            Author author = await _context.Author.FindAsync(id);

            return author;
        }
    }
}