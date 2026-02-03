using BookstoreApplication.DTOs;

namespace BookstoreApplication.Models
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);
        Task<bool> DeleteAsync(int id);
        Task<List<Book>> GetAllAsync(string order, string orderDirection);
        Task<Book?> GetByIdAsync(int id);
        Task<Book> UpdateAsync(Book book);
    }
}