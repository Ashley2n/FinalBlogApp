namespace Blog.Domain.Entities;

public class BlogPost
{
    // going to add entity annotations in db context
    public int Id { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateEdited { get; set; }
    public string Content { get; set; }
}