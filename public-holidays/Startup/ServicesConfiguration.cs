using public_holidays.Repositories;
using public_holidays.Services;

namespace public_holidays.Startup;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICountryRepository, CountryRepository>()
            .AddScoped<IHolidayRepository, HolidayRepository>()
            .AddScoped<ICountryService, CountryService>()
            .AddScoped<IHolidayService, HolidayService>();
        
        services.AddHttpClient<HolidayApiService>();
        // services.AddRefitClient<IHolidayApi>().ConfigureHttpClient(c =>
        // {
        //     c.BaseAddress = new Uri(configuration["HolidayApi:BaseUrl"]);
        // });
    }
}   