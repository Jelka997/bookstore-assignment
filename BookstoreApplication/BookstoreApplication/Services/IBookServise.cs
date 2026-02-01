using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IBookServise
    {
        Task<Book> AddAsync(Book book);
        Task<bool> DeleteAsync(int id);
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> UpdateAsync(Book book);
    }
}