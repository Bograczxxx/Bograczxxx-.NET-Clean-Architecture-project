using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Pages;

public class IndexModel : PageModel
{
    private readonly AuthorService _service;

    public IndexModel(AuthorService service)
    {
        _service = service;
    }

    public IList<Author> Authors { get; set; } = new List<Author>();

    public async Task OnGet()
    {
        Authors = (await _service.GetAllAsync()).ToList();
    }
}
