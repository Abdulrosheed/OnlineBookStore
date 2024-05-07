using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Entities;

namespace OnlineBookstore.Context;
public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Sale> Sales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    DataSeeder.Seed(modelBuilder);
}
}