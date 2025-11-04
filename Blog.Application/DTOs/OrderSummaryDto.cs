
namespace Blog.Application.DTOs;

public record OrderSummaryDto
{
    
    
    public int Id { get; set; }           
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    
}