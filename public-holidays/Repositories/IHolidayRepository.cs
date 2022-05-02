using public_holidays.Data.Models;

namespace public_holidays.Repositories;

public interface IHolidayRepository
{
    Task<ICollection<Holiday>> CreateManyAsync(ICollection<Holiday> holidays);
    Task<ICollection<Holiday>> GetAllForCountryAndYearAsync(string countryCode, string year);
}