using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class AuthorService
{
    private readonly IAuthorRepository _repo;

    public AuthorService(IAuthorRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Author>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Author?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
    public Task<Author> AddAsync(Author author) => _repo.AddAsync(author);
    public Task UpdateAsync(Author author) => _repo.UpdateAsync(author);
    public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
}
