using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositorys
{
    public class BookRepository
    {
        private AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public Book Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return book;
        }

        public bool Delete(int id)
        {
            Book book = _context.Books.Find(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }

        public List<Book> GetAll()
        {
            return _context.Books
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .ToList();
        }

        public Book? GetById(int id)
        {
            return _context.Books
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .FirstOrDefault(b => b.Id == id);
        }
    }
}
