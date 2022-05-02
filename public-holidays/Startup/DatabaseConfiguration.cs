using System.Runtime.CompilerServices;
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
    }
    
    
    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var conStrBuilder = new SqlConnectionStringBuilder(
        configuration.GetConnectionString("DefaultConnection"));
        conStrBuilder.Password = configuration["DbPassword"];
        var connection = conStrBuilder.ConnectionString;

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
    }
    private static void MigrateDatabase(this IServiceCollection services)
    {
        services
            .BuildServiceProvider()
            .GetService<ApplicationDbContext>()?
            .Database.Migrate();
    }
}