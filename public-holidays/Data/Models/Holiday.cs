using System.ComponentModel.DataAnnotations.Schema;

namespace public_holidays.Data.Models;

public class Holiday
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    
    public Country Country { get; set; }
    [ForeignKey("Country")]
    public string CountryCode { get; set; }
}