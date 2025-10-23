using Blog.Application.Interfaces;

namespace Blog.Application.Services;

public sealed class BlogService : IBlogService
{
    private readonly IBlogServiceRepository _blogService;
    // using the repository
    
    public BlogService(IBlogServiceRepository blogService)
    {
        _blogService = blogService;
    }

    public async Task<BlogPostDTO> CreateBlogPostAsync(string author, DateTime dateCreated, string title,
        string bodyText, CancellationToken ct = default)
    {
        var blogPost = new BlogPostDTO
        {
            Author = author,
            DateCreated = dateCreated,
            Title = title,
            BodyText = bodyText,
        };
        await _blogService.Add(blogPost, ct);
        return blogPost;
    }

    public async Task<BlogPostDTO> UpdateBlogPostAsync(CancellationToken ct = default)
    {
        return await _blogService.UpdateBlogPostAsync(ct);
    }

    public async Task<BlogPostDTO> DeleteBlogPostAsync(CancellationToken ct = default)
    {
        return await _blogService.DeleteBlogPostAsync(ct);
    }

    public async Task<BlogPostDTO> GetBlogPostByIdAsync(int blogPostId, CancellationToken ct = default)
    {
        return await _blogService.GetBlogPostByIdAsync(blogPostId, ct);
    }

    public async Task<List<BlogPostDTO>> GetAllBlogPostsAsync(CancellationToken ct = default) =>
        (await _blogService.GetAll(ct).Select(###.ToList());


}