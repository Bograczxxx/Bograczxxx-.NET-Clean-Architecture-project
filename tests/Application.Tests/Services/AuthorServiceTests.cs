using System.Collections.Generic;
using Xunit;
using Application.Services;
using Application.Interfaces;
using Domain.Entities;
using Moq;

namespace Application.Tests.Services;

public class AuthorServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsAuthors()
    {
        var mockRepo = new Mock<IAuthorRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Author> { new Author { Id = 1, Name = "Test" } });
        var service = new AuthorService(mockRepo.Object);

        var result = await service.GetAllAsync();

        Assert.Single(result);
    }
}
