namespace Blog.Application.DTO.BlogPosts;

public class UpdateBlogPostDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime Modified { get; set; } = DateTime.UtcNow;
}