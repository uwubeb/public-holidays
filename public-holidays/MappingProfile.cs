using System.Text.RegularExpressions;
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
        CreateMap<Holiday, HolidayDto>().ReverseMap();
        CreateMap<HolidaysForCountryResponse, Holiday>()
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => src.Names.LastOrDefault().Text))// english name
            .ReverseMap();
        CreateMap<DateResponse, DateTime>().ForMember(dest => dest.Date, opt =>
        opt.MapFrom(src => new DateTime(src.Year, src.Month, src.Day)));
        // CreateMap<DateOnly, DateResponse>()
        //     .ForMember(dest => dest.Year, opt =>
        //         opt.MapFrom(src => src.Year))
        //     .ForMember(dest => dest.Month, opt =>
        //         opt.MapFrom(src => src.Month))
        //     .ForMember(dest => dest.Day, opt =>
        //         opt.MapFrom(src => src.Day))
        //     .ReverseMap();
        // .ForMember(dest => dest, opt =>
        //     opt.MapFrom(src => new DateOnly(src.Year, src.Month, src.Day)));

    }
}