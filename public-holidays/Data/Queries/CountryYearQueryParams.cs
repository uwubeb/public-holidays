using System.ComponentModel.DataAnnotations;

namespace public_holidays.Data.Queries;

public class CountryYearQueryParams
{
    [Required]
    [StringLength(3)]
    public string CountryCode { get; set; }
    
    [Required]
    [Range(2011, 32767)] // range from public api
    public int Year { get; set; }
}