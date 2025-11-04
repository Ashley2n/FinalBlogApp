using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<BlogPost> Blogs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<BlogPost>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            e.Property(x => x.Title)
                .IsRequired();
            // Add additional Configurations Here
            e.Property(x => x.Content)
                .HasMaxLength(1000);
        });

        b.Entity<User>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            e.Property(x => x.FirstName)
                .IsRequired();
            e.Property(x => x.LastName)
                .IsRequired();
            e.Property(x => x.Email)
                .IsRequired();
            e.Property(x => x.Password)
                .IsRequired();
            e.Property(x => x.AccountCreationDate)
                .IsRequired();
            e.Property(x => x.PhoneNumber)
                .IsRequired();
            e.Property(x => x.ProfileImage)
                .IsRequired();
        });
    }
}


// dotnet ef migrations add Init --project ..\Blog.Infrastructure\ --startup-project .
// dotnet ef database update --project ..\Blog.Infrastructure\ --startup-project .