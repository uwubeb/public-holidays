using public_holidays.api.Responses;

namespace public_holidays.Data.Dtos;

public class GroupedHolidaysDto
{
    public int Month { get; set; }
    public ICollection<HolidayDto> Holidays { get; set; }
}