using Blog.Application.DTO.BlogPosts;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Server.Controller;

[ApiController]
[Route("api/[controller]")]

public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;
    public BlogController(IBlogService blogService) =>  _blogService = blogService;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await _blogService.GetAllBlogPostsAsync(ct));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogPostById([FromRoute] int id, CancellationToken ct)
    {
        var entity = await _blogService.GetBlogPostByIdAsync(id, ct);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> AddBlogPost([FromBody] CreateBlogPostDto blogPost, CancellationToken ct = default)
    {
        var created = await _blogService.CreateBlogPostAsync(blogPost, ct);
        return Ok(created);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBlogPost([FromBody] UpdateBlogPostDto blogPost, CancellationToken ct = default)
    {
        var updated = await _blogService.UpdateBlogPostAsync(blogPost, ct);
        return Ok(updated);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBlogPost(BlogPostDto blogPost, CancellationToken ct = default)
    {
        var  deleted = await _blogService.DeleteBlogPostAsync(blogPost, ct);
        return Ok(deleted ? "Delete" : throw new Exception("Delete failed"));
    }
}