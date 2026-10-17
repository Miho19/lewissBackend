using Microsoft.AspNetCore.Mvc;

namespace LewissBackend.API.Controller;


[ApiController]
[Route("[controller]")]
public class StaffController : ControllerBase
{
    private static readonly List<string> Staff =
    [
      "Joshua"
    ];

    [HttpGet(Name = "GetStaffList")]
    public async Task<IActionResult> GetStaff()
    {
        return Ok(Staff);
    }
}