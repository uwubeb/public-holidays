using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace public_holidays.Data.Models;

public class Day
{
    public Guid Id  { get; init; }

    public DateTime Date { get; set; }
    
    public bool IsWorkDay { get; set; }

    public Country Country { get; set; }
    [ForeignKey("Country")]
    public string CountryCode { get; set; }
    

    
}
    