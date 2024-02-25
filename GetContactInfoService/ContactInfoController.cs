using Microsoft.AspNetCore.Mvc;

namespace GetContactInfoService;

[ApiController]
[Route("api/[controller]")]
public class ContactInfoController : ControllerBase
{
    [HttpGet]
    public IActionResult GetContactInfo()
    {
        return Ok("Contact Information");
    }
}