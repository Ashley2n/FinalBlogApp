using System.ComponentModel.DataAnnotations;
using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface IBlogService
{
    Task<BlogPost> CreateBlogPostAsync(CreateBlogPostDto dto, CancellationToken ct = default);
    Task<BlogPost> UpdateBlogPostAsync(UpdateBlogPdtDto dto, CancellationToken ct = default);
    Task<bool> DeleteBlogPostAsync(BlogPostDto dto, CancellationToken ct = default);
    Task<BlogPost> GetBlogPostByIdAsync(int blogPostId, CancellationToken ct = default);
    Task<List<BlogPost>> GetAllBlogPostsAsync(CancellationToken ct = default);
    
}