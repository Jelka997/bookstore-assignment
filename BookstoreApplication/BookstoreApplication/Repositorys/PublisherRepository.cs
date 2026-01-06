using BookstoreApplication.Models;

namespace BookstoreApplication.Repositorys
{
    public class PublisherRepository
    {
        private AppDbContext _context;

        public PublisherRepository(AppDbContext context)
        {
            _context = context;
        }

        public Publisher Add(Publisher publisher)
        {
            _context.Publisher.Add(publisher);
            _context.SaveChanges();
            return publisher;
        }

        public Publisher Update(Publisher publisher)
        {
            _context.Publisher.Update(publisher);
            _context.SaveChanges();
            return publisher;
        }

        public bool Delete(int id)
        {
            Publisher publisher = _context.Publisher.Find(id);
            if ( publisher == null)
            {
                return false;
            }

            _context.Publisher.Remove(publisher);
            _context.SaveChanges();
            return true;
        }

        public List<Publisher> GetAll()
        {
            return _context.Publisher.ToList();
        }

        public Publisher? GetById(int id)
        {
            return _context.Publisher.Find(id);
        }
    }
}
