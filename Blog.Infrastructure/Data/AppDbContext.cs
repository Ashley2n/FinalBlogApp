using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Blog.Infrastructure.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Blog>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            e.Property(x => x.Title)
                .IsRequired();
            // Add additional Configurations Here
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