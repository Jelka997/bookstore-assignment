using BookstoreApplication.Models;

namespace BookstoreApplication.Repositorys
{
    public class AuthorRepository
    {
        private AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Author Add(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
            return author;
        }

        public Author Update(Author author)
        {
            _context.Author.Update(author);
            _context.SaveChanges();
            return author;
        }

        public bool Delete(int id)
        {
            Author author = _context.Author.Find(id);
            if (author == null)
            {
                return false;
            }

            _context.Author.Remove(author);
            _context.SaveChanges();
            return true;
        }

        public List<Author> GetAll()
        {
            return _context.Author.ToList();
        }

        public Author? GetById(int id)
        {
            return _context.Author.Find(id);
        }
    }
}