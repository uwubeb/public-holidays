using Microsoft.EntityFrameworkCore;
using public_holidays.Data.Models;

namespace public_holidays.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Holiday> Holidays { get; set; }
    public DbSet<Country> Countries { get; set; }
}