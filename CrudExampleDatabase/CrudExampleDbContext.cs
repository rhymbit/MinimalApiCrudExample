using CrudExampleDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudExampleDatabase;

public class CrudExampleDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public string DbPath { get; }

    public CrudExampleDbContext() =>
        DbPath = Path.Combine(Environment.CurrentDirectory, "database.db");


    public CrudExampleDbContext(DbContextOptions<CrudExampleDbContext> options) : 
        base(options) =>
        DbPath = Path.Combine(Environment.CurrentDirectory, "database.db");

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
      options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
      modelBuilder.Entity<User>().ToTable("Users")
        .HasKey(u => u.Id)
        .HasName("PK_Users");

}