using Domain.Entities;

namespace Application.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    Task<Author> AddAsync(Author author);
    Task UpdateAsync(Author author);
    Task DeleteAsync(int id);
}
