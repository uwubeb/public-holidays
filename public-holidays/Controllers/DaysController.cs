using Microsoft.AspNetCore.Mvc;
using public_holidays.Services;

namespace public_holidays.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DaysController : Controller
{
    private readonly IDayService _dayService;
    
    public DaysController(IDayService dayService)
    {
        _dayService = dayService;
        
    }
    
   

}