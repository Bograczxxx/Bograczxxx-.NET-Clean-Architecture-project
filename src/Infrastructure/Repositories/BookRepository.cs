using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.Include(b => b.Reviews).ToListAsync();

    public async Task<Book?> GetByIdAsync(int id) => await _context.Books.Include(b => b.Reviews).FirstOrDefaultAsync(b => b.Id == id);

    public async Task<Book> AddAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task UpdateAsync(Book book)
    {
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Books.FindAsync(id);
        if (entity is null) return;
        _context.Books.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
