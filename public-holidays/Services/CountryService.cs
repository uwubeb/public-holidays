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
    // private readonly IHolidayApi  _holidayApi;
    private readonly HolidayApiService _holidayApiService;
    private readonly IMapper _mapper;
    public CountryService(ICountryRepository countryRepository, IMapper mapper, HolidayApiService holidayApiService)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
        _holidayApiService = holidayApiService;
    }

    public async Task<ICollection<CountryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var countriesFromDb = await _countryRepository.GetAllAsync(cancellationToken);
        if (countriesFromDb.Count() == 0 )
        {
            var countriesFromApi = await _holidayApiService.GetSupportedCountriesAsync();
            var countriesDto = _mapper.Map<List<CountryDto>>(countriesFromApi);
            var countriesModels = _mapper.Map<List<Country>>(countriesFromApi);
            await _countryRepository.CreateMany(countriesModels);
            return countriesDto;
        }
            
        return  _mapper.Map<ICollection<CountryDto>>(countriesFromDb);
    }
}