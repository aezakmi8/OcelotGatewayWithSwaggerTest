using Microsoft.AspNetCore.Mvc;

namespace GetCustomerInfoService;

[ApiController]
[Route("api/[controller]")]
public class CustomerInfoController : ControllerBase
{
    [HttpGet]
    [Route("[action]")]
    public IActionResult Get()
    {
        return Ok("Customer Information");
    }
    
    
    [HttpGet]
    [Route("[action]/{info}")]
    public IActionResult GetByInfo(string info)
    {
        return Ok($"Customer Information {info}");
    }
    
    
    [HttpPost]
    public IActionResult Set([FromBody] CustomerInfo info)
    {
        return Ok($"Customer Information {info.Name}, {info.AltName}");
    }
}

public class CustomerInfo
{
    public string Name { get; set; }
    public string AltName { get; set; }
}