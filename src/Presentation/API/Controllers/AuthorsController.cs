using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly AuthorService _service;

    public AuthorsController(AuthorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Author>> Get() => await _service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> Get(int id)
    {
        var author = await _service.GetByIdAsync(id);
        if (author == null) return NotFound();
        return author;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Author>> Post([FromBody] Author author)
    {
        var created = await _service.AddAsync(author);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Author author)
    {
        if (id != author.Id) return BadRequest();
        await _service.UpdateAsync(author);
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
