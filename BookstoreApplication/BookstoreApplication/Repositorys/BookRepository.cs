using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositorys
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Book>> GetAllAsync(string order, string orderDirection)
        {
            IQueryable<Book> query = _context.Books
                .Include(a => a.Author)
                .Include(p => p.Publisher);

            if (order == "Name")
            {
                query = orderDirection == "ASC" ? query.OrderBy(n => n.Title) : query.OrderByDescending(n => n.Title);
            }
            else if (order == "Date")
            {
                query = orderDirection == "ASC" ? query.OrderBy(d => d.PublishedDate) : query.OrderByDescending(d => d.PublishedDate);
            }
            else if (order == "Author")
            {
                query = orderDirection == "ASC" ? query.OrderBy(a => a.Author.FullName) : query.OrderByDescending(a => a.Author.FullName);
            }

            return await query.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Book>> BookSearchAsync(BookSearchDto bookSearchDto)
        {
            IQueryable<Book> books = _context.Books
                 .Include(a => a.Author)
                 .Include(p => p.Publisher);
                    

            if (!string.IsNullOrWhiteSpace(bookSearchDto.Title))
            {
                books = books
                    .Where(t => t.Title.ToLower().Contains(bookSearchDto.Title.ToLower()));
            }
            if (bookSearchDto.PublishedFrom.HasValue)
            {
                books = books
                    .Where(d => d.PublishedDate >= bookSearchDto.PublishedFrom);
            }
            if (bookSearchDto.PublishedTo.HasValue)
            {
                books = books
                    .Where(d => d.PublishedDate <= bookSearchDto.PublishedTo);
            }
            if (bookSearchDto.AuthorId.HasValue)
            {
                books = books
                    .Where(a => a.AuthorId == bookSearchDto.AuthorId);
            }
            if (!string.IsNullOrWhiteSpace(bookSearchDto.AuthorName))
            {
                books = books
                    .Where(a => a.Author.FullName.ToLower().Contains(bookSearchDto.AuthorName.ToLower()));
            }
            if (bookSearchDto.AuthorBirthDateFrom.HasValue)
            {
                books = books
                    .Where(d => d.Author.DateOfBirth >= bookSearchDto.AuthorBirthDateFrom);
            }
            if (bookSearchDto.AuthorBirthDateTo.HasValue)
            {
                books = books
                    .Where(d => d.Author.DateOfBirth <= bookSearchDto.AuthorBirthDateTo);
            }

            return await books.ToListAsync();
        }


        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = _context.Books
                .Include(a => a.Author)
                .Include(p => p.Publisher);

            return await books.ToListAsync();
        }
    }
}