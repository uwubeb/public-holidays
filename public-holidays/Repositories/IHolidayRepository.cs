using public_holidays.Data.Models;

namespace public_holidays.Repositories;

public interface IHolidayRepository
{
    Task CreateAsync(Holiday holiday);
    Task<ICollection<Holiday>> CreateManyAsync(ICollection<Holiday> holidays);
    Task<ICollection<Holiday>> GetAllForCountryAndYearAsync(string countryCode, string year);
    Task<Holiday?> GetByCountryAndDateAsync(string countryCode, DateTime date);

}