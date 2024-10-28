using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User> (entity => {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Username).IsRequired();
            entity.Property(u => u.Password).IsRequired();
            entity.Property(u => u.Admin).IsRequired();
        });

        modelBuilder.Entity<Book> (entity => {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Title).IsRequired();
            entity.Property(b => b.Author).IsRequired();
        });
    }
}
