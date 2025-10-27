using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Infrastructure.Data;

namespace Blog.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext db) : base(db)
    {
        
    }
}