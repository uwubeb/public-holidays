using System.ComponentModel.DataAnnotations;

namespace public_holidays.Data.Queries;

public class CountryDateQueryParams
{
    [Required]
    [StringLength(3)]
    public string CountryCode { get; set; }
    
    [Required]
    [Range(2011, 32767)] // range from public api
    public string Year { get; set; }
    [Required]
    [Range(1, 12)]
    public string Month { get; set; }
    
    [Required]
    [Range(1, 31)] // different for different months but not going to handle that
    public string Day { get; set; }
}