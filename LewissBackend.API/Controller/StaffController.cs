using System.Reflection.Metadata.Ecma335;
using FluentResults;
using LewissBackend.API.CustomError;
using LewissBackend.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace LewissBackend.API.Controller;


[ApiController]
[Route("[controller]")]
public class StaffController : ControllerBase
{
    private readonly IStaffService _staffService;
    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [HttpGet(Name = "GetStaffList")]
    public async Task<IActionResult> GetStaff(CancellationToken cancellationToken)
    {
        var result = await _staffService.GetStaffListAsync(cancellationToken);

        if (result.IsSuccess) return Ok(result.Value);

        var error = result.Errors[0];

        return error switch
        {
            ListEmptyError => NoContent(),
            _ => StatusCode(500, "Unexpected error occured")
        };


    }
}