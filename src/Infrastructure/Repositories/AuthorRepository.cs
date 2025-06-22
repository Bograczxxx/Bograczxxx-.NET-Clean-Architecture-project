using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAllAsync() => await _context.Authors.Include(a => a.Books).ToListAsync();

    public async Task<Author?> GetByIdAsync(int id) => await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Author> AddAsync(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return author;
    }

    public async Task UpdateAsync(Author author)
    {
        _context.Entry(author).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Authors.FindAsync(id);
        if (entity is null) return;
        _context.Authors.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
