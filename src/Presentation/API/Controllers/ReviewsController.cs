using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly ReviewService _service;

    public ReviewsController(ReviewService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Review>> Get() => await _service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> Get(int id)
    {
        var review = await _service.GetByIdAsync(id);
        if (review == null) return NotFound();
        return review;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Review>> Post([FromBody] Review review)
    {
        var created = await _service.AddAsync(review);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Review review)
    {
        if (id != review.Id) return BadRequest();
        await _service.UpdateAsync(review);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
