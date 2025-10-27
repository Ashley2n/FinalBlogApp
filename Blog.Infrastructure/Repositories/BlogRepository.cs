using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Infrastructure.Data;

namespace Blog.Infrastructure.Repositories;

public class BlogRepository : GenericRepository<BlogPost>, IBlogPostRepository
{
    public BlogRepository(AppDbContext db) : base(db) { }
    
    // add custom queries here
}