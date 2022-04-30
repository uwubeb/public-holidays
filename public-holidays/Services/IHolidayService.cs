﻿using public_holidays.api.Responses;

namespace public_holidays.Services;

public interface IHolidayService
{
    public Task<IReadOnlyList<HolidaysForCountryResponse>> GetHolidaysForCountryAndYearAsync(string countryCode, string year);
}