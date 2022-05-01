using public_holidays.api.Responses;
using public_holidays.Data.Dtos;

namespace public_holidays.Services;

public interface IHolidayService
{
    public Task<ICollection<GroupedHolidaysDto>> GetHolidaysForCountryAndYearAsync(string countryCode, string year);

    public Task<DayStatusDto> GetDayStatusAsync(string countryCode, string year, string month, string day);
}