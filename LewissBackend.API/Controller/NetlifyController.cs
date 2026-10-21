using LewissBackend.API.Model.DTO;
using LewissBackend.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace LewissBackend.API.Controller;

[ApiController]
[Route(".netlify/functions/graph")]
public class NetlifyController : ControllerBase
{
    private readonly INetlifyService _netlifyService;
    public NetlifyController(INetlifyService netlifyService)
    {
        _netlifyService = netlifyService;
    }

    [HttpPost(Name = "MainRequestHandler")]
    public async Task<IActionResult> RequestHandler([FromBody] NetlifyRequestPayloadDTO body, CancellationToken cancellationToken)
    {

        var result = await _netlifyService.GetRequestedItemAsync(body, cancellationToken);

        if (result.IsSuccess) return Ok(result.Value);

        var error = result.Errors[0];

        return error switch
        {
            _ => StatusCode(500, "Unexpected error occured")
        };

    }
}