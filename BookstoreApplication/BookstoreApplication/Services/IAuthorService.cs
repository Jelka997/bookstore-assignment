using BookstoreApplication.DTOs;
using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IAuthorService
    {
        Task<Author> AddAsync(Author author);
        Task<bool> DeleteAsync(int id);
        Task<PaginatedListDto<Author>> GetAllAsync(int page, int pageSize);
        Task<Author?> GetByIdAsync(int id);
        Task<Author> UpdateAsync(int id, Author author);
    }
}