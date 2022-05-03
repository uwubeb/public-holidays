using System.ComponentModel.DataAnnotations;

namespace public_holidays.Data.Queries;

public class CountryDateQueryParams
{
    [Required]
    [StringLength(3, MinimumLength = 3)]
    public string CountryCode { get; set; }
    
    //ints for Required annotation
    [Required]
    [Range(2011, 9999)] // min from api restrictions, max from DateTime restrictions
    public int Year { get; set; }
    [Required]
    [Range(1, 12)]
    public int Month { get; set; }
    
    [Required]
    [Range(1, 31)] // different for different months but not going to handle that
    public int Day { get; set; }
}