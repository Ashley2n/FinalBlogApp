using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Interfaces;

public interface IBlogService
{
    Task<BlogPostDTO> CreateBlogPostAsync(string title, string content, CancellationToken ct = default);
    Task<BlogPostDTO> UpdateBlogPostAsync(CancellationToken ct = default);
    Task<BlogPostDTO> DeleteBlogPostAsync(CancellationToken ct = default);
    Task<BlogPostDTO> GetBlogPostByIdAsync(int blogPostId, CancellationToken ct = default);
    Task<List<BlogPostDTO>> GetAllBlogPostsAsync(CancellationToken ct = default);
    
}