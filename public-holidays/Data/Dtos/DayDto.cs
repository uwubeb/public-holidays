namespace public_holidays.Data.Dtos;

public record DayDto
{
    public DateTime Date { get; init; }
    public string HolidayName { get; init; }
    public string Status { get; init; }
}