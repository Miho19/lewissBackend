using Microsoft.AspNetCore.Mvc;

namespace LewissBackend.API.Controllers;


[ApiController]
[Route("[controller]")]
public class StaffController : ControllerBase
{
    private static readonly string[] Staff =
    [
      "Joshua"
    ];

    [HttpGet(Name = "GetStaffList")]
    public async Task<IActionResult> GetStaff()
    {
        return Ok(Staff);
    }
}