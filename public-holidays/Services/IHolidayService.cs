using public_holidays.Data.Dtos;

namespace public_holidays.Services;

public interface IHolidayService
{
    public Task<ICollection<GroupedHolidaysDto>> GetHolidaysForCountryAndYearGroupedAsync(string countryCode, string year);

    public Task<DayStatusDto> GetDayStatusAsync(string countryCode, string year, string month, string day);
    public Task<int> GetMaxFreeDaysForCountryAndYearAsync(string countryCode, string year);



}