using public_holidays.api.Responses;

namespace public_holidays.Services;

public class HolidayApiService
{
    private readonly HttpClient _httpClient;
    
    public HolidayApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://kayaposoft.com");
    }

    public async Task<IReadOnlyList<HolidaysForCountryResponse>> GetHolidaysForCountryAndYearAsync(string countryCode, string year)
    {
        return await _httpClient.GetFromJsonAsync<IReadOnlyList<HolidaysForCountryResponse>>(
        "/enrico/json/v2.0/?action=getHolidaysForYear&year=" + year + "&country=" + countryCode);
    }
}