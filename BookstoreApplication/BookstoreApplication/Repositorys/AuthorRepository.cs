using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositorys
{
    public class AuthorRepository : IAuthorRepository
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
            Author author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PaginatedListDto<Author>> GetAllAsync(int page, int pageSize)
        {
            int pageIndex = page - 1;
            var authors = _context.Author
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            var count = await _context.Author.CountAsync();
            PaginatedListDto<Author> result = new PaginatedListDto<Author>(authors, count, pageIndex, pageSize);
            return result;
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            Author author = await _context.Author.FindAsync(id);

            return author;
        }
    }
}