using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace LewissBackend.API.Controller;

[ApiController]
[Route(".netlify/functions/graph")]
public class NetlifyController : ControllerBase
{
    [HttpPost(Name = "MainRequestHandler")]
    public async Task<IActionResult> RequestHandler([FromBody] JsonElement body, CancellationToken cancellationToken)
    {

        return BadRequest();
    }
}