namespace public_holidays.Services;

public interface IDayService
{
    public Task<int> GetMaxFreeDaysAsync(string countryCode, string year);

}