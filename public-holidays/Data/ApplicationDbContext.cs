using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using public_holidays.Data.Models;

namespace public_holidays.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>()
            .HasMany(c => c.Holidays)
            .WithOne(h => h.Country)
            .HasForeignKey(h => h.CountryCode);
    }
    
    public DbSet<Holiday> Holidays { get; set; }
    public DbSet<Country> Countries { get; set; }
}