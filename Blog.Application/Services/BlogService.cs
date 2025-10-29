using Blog.Application.DTO.BlogPosts;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Infrastructure.Repositories;

namespace Blog.Application.Services;

public sealed class BlogService : IBlogService
{
    private readonly BlogRepository _blogService;
    // using the repository
    
    public BlogService(BlogRepository blogService)
    {
        _blogService = blogService;
    }

    public async Task<BlogPost> CreateBlogPostAsync(CreateBlogPostDto dto, CancellationToken ct = default)
    {
        var blog = new BlogPost
        {
            Author = dto.Author,
            Title = dto.Title,
            Content = dto.Content,
        };
        await _blogService.AddAsync(blog, ct);
        return blog;
    }

    public async Task<BlogPost> UpdateBlogPostAsync(UpdateBlogPostDto dto, CancellationToken ct = default)
    {
        var blog = await _blogService.GetById(dto.Id, ct);

        blog.Title = dto.Title;
        blog.Content = dto.Content;
        blog.Modified = DateTime.UtcNow;
        
        await _blogService.UpdateAsync(blog, ct);
        return blog;
    }

    public async Task<bool> DeleteBlogPostAsync(BlogPostDto dto, CancellationToken ct = default)
    {
        var blog = await _blogService.GetById(dto.Id, ct);
        if (blog == null) return false;
        
        await _blogService.DeleteAsync(blog, ct);
        return true;
    }

    public async Task<BlogPost> GetBlogPostByIdAsync(int id, CancellationToken ct = default) =>
            await _blogService.GetById(id, ct);

    public async Task<List<BlogPost>> GetAllBlogPostsAsync(CancellationToken ct = default) =>
        await _blogService.GetAll(ct);


}