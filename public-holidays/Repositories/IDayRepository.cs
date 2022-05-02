using public_holidays.Data.Models;

namespace public_holidays.Repositories;

public interface IDayRepository
{
    public bool? IsWorkDay(Day day);
    public Task CreateDayAsync(Day day);
}