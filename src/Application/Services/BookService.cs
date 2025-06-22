using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class BookService
{
    private readonly IBookRepository _repo;

    public BookService(IBookRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Book>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Book?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
    public Task<Book> AddAsync(Book book) => _repo.AddAsync(book);
    public Task UpdateAsync(Book book) => _repo.UpdateAsync(book);
    public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
}
