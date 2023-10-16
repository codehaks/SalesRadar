using Microsoft.EntityFrameworkCore;
using SalesRadar.Domain;
using SalesRadar.Infrastruture.DataModels;

namespace SalesRadar.Infrastruture;

public class SalesRadarDbContext : DbContext
{
    public SalesRadarDbContext(DbContextOptions<SalesRadarDbContext> options)
           : base(options)
    {
    }

    public DbSet<CustomerData> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerData>()
            .HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth })
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
