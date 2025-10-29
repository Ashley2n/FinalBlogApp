namespace Blog.Application.DTO.BlogPosts;

public class BlogPostDto
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}