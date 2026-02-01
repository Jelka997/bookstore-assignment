using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IAuthorService
    {
        Task<Author> AddAsync(Author author);
        Task<bool> DeleteAsync(int id);
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<Author> UpdateAsync(Author author);
    }
}