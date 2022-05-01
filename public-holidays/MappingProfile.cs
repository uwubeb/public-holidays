using AutoMapper;
using public_holidays.api.Responses;
using public_holidays.Data.Dtos;
using public_holidays.Data.Models;

namespace public_holidays;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, SupportedCountryResponse>().ReverseMap();
        CreateMap<SupportedCountryResponse, CountryDto>().ReverseMap();
        





    }
}