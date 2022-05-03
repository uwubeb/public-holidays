using System.ComponentModel.DataAnnotations;

namespace public_holidays.Data.Queries;

public class CountryYearQueryParams
{
    [Required]
    [StringLength(3, MinimumLength = 3)]
    public string CountryCode { get; set; }
    
    //int for Required annotation
    [Required]
    [Range(2011, 9999)] // min from api restrictions, max from DateTime restrictions
    public int Year { get; set; }
}