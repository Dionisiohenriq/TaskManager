using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskManager.Domain.Entities;

namespace TaskManager.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonTask> Tasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasKey(p => p.Id);
        modelBuilder.Entity<Person>().Property(p => p.Name).HasMaxLength(100);
        modelBuilder.Entity<Person>().Property(p => p.Email).HasMaxLength(150);

        modelBuilder.Entity<PersonTask>().HasKey(p => p.Id);
        modelBuilder.Entity<PersonTask>().Property(p => p.Title).HasMaxLength(150);
        modelBuilder.Entity<PersonTask>().Property(p => p.Description).HasMaxLength(500);
        modelBuilder.Entity<PersonTask>().Property(p => p.Status).HasConversion<string>();
        modelBuilder.Entity<PersonTask>().HasOne(t => t.Person).WithMany(p => p.Tasks);
        base.OnModelCreating(modelBuilder);
    }
}