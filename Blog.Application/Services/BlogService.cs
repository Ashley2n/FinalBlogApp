using Blog.Application.DTO.BlogPosts;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Infrastructure.Repositories;

namespace Blog.Application.Services;

public sealed class BlogService : IBlogService
{
    private readonly IBlogPostRepository _blogRepository;
    // using the repository
    
    public BlogService(IBlogPostRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<BlogPost> CreateBlogPostAsync(CreateBlogPostDto dto, CancellationToken ct = default)
    {
        var blog = new BlogPost
        {
            Author = dto.Author,
            Title = dto.Title,
            Content = dto.Content,
        };
        await _blogRepository.AddAsync(blog, ct);
        return blog;
    }

    public async Task<BlogPost> UpdateBlogPostAsync(UpdateBlogPostDto dto, CancellationToken ct = default)
    {
        var blog = await _blogRepository.GetById(dto.Id, ct);

        blog.Title = dto.Title;
        blog.Content = dto.Content;
        blog.Modified = DateTime.UtcNow;
        
        await _blogRepository.UpdateAsync(blog, ct);
        return blog;
    }

    public async Task<bool> DeleteBlogPostAsync(BlogPostDto dto, CancellationToken ct = default)
    {
        var blog = await _blogRepository.GetById(dto.Id, ct);
        if (blog == null) return false;
        
        await _blogRepository.DeleteAsync(blog, ct);
        return true;
    }

    public async Task<BlogPost> GetBlogPostByIdAsync(int id, CancellationToken ct = default) =>
            await _blogRepository.GetById(id, ct);

    public async Task<List<BlogPost>> GetAllBlogPostsAsync(CancellationToken ct = default) =>
        await _blogRepository.GetAll(ct);


}