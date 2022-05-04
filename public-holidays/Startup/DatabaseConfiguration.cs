using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using public_holidays.Data;

namespace public_holidays.Startup;

public static class DatabaseConfiguration
{
    
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.MigrateDatabase();
        services.SeedDatabase();
    }
    
    
    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var conStrBuilder = new StringBuilder(
        configuration["ConnectionStrings:HolidayConnectionMssql"]);
        // conStrBuilder.Password = configuration["DbPassword"];
        string conn = conStrBuilder
            .Replace("ENVID", configuration["DB_User"])
            .Replace("ENVPW", configuration["DB_Password"])
            .Replace("ENVSERVER", configuration["DB_Server"])
            .ToString();

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conn));
    }
    private static void MigrateDatabase(this IServiceCollection services)
    {
        services
            .BuildServiceProvider()
            .GetService<ApplicationDbContext>()?
            .Database.Migrate();
    }
    
    private static void SeedDatabase(this IServiceCollection services)
    {
        var seeder = services.BuildServiceProvider().GetService<CountrySeeder>();
        seeder.SeedCountriesFromApi();
    }
}