
using Microsoft.EntityFrameworkCore;
using SalesRadar.Domain;

namespace BugNet.Data;

public class SalesRadarDbContext:DbContext
{
    public SalesRadarDbContext(DbContextOptions<SalesRadarDbContext> options)
           : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth })
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
