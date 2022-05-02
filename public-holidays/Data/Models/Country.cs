using System.ComponentModel.DataAnnotations;

namespace public_holidays.Data.Models;

public class Country
{
    [Key]
    public string CountryCode { get; set; }
    public string Name { get; set; }
    
    public ICollection<Holiday> Holidays { get; set; }
}