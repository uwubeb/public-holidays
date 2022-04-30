using public_holidays.api;
using public_holidays.Repositories;
using public_holidays.Services;
using Refit;

namespace public_holidays.Startup;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services
            .AddScoped<ICountryRepository, CountryRepository>()
            .AddScoped<ICountryService, CountryService>();
        services.AddRefitClient<IHolidayApi>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(configuration["HolidayApi:BaseUrl"]);
        });
    }
}   