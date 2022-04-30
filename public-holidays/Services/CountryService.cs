using System.Text.Json;
using AutoMapper;
using public_holidays.api;
using public_holidays.api.Responses;
using public_holidays.Data.Dtos;
using public_holidays.Data.Models;
using public_holidays.Repositories;

namespace public_holidays.Services;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;
    private readonly IHolidayApi  _holidayApi;
    private readonly IMapper _mapper;
    public CountryService(ICountryRepository countryRepository, IMapper mapper, IHolidayApi holidayApi)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
        _holidayApi = holidayApi;
    }

    public async Task<IReadOnlyList<SupportedCountryResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        // var streamTask = _client.GetStreamAsync("https://kayaposoft.com/enrico/json/v2.0/?action=getSupportedCountries&start=0&limit=1000");
        // var options = new JsonSerializerOptions
        // {
        //     PropertyNameCaseInsensitive = true,
        // };
        // var countries = await JsonSerializer.DeserializeAsync<ICollection<Country>>(await streamTask, options);
        // var countriesDto = _mapper.Map<ICollection<CountryDto>>(countries);
        // return countriesDto;
        return await _holidayApi.GetCountriesAsync();
    }
}