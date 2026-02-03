using BookstoreApplication.DTOs;
using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IBookServise
    {
        Task<Book> AddAsync(Book book);
        Task<bool> DeleteAsync(int id);
        Task<List<BookDto>> GetAllAsync(string order, string orderDirection);
        Task<BookDetailsDto?> GetByIdAsync(int id);
        Task<Book> UpdateAsync(int id, Book book);
    }
}