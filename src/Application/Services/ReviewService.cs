using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class ReviewService
{
    private readonly IReviewRepository _repo;

    public ReviewService(IReviewRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Review>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Review?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
    public Task<Review> AddAsync(Review review) => _repo.AddAsync(review);
    public Task UpdateAsync(Review review) => _repo.UpdateAsync(review);
    public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
}
