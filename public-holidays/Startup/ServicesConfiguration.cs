using System.Text.Json.Serialization;
using public_holidays.Repositories;
using public_holidays.Services;
using public_holidays.Utils;

namespace public_holidays.Startup;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICountryRepository, CountryRepository>()
            .AddScoped<IHolidayRepository, HolidayRepository>()
            .AddScoped<ICountryService, CountryService>()
            .AddScoped<IHolidayService, HolidayService>()
            .AddScoped<CountrySeeder>();
        
        services.AddHttpClient<HolidayApiService>();
        
        services.AddSwaggerGen();
        services.AddSwaggerDocument();

        services.AddAutoMapper(typeof(Program));
        
        

        services.AddControllers().AddJsonOptions(x => {
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            x.JsonSerializerOptions.Converters.Add(new CustomDateTimeConverter());
        });
    }
}   