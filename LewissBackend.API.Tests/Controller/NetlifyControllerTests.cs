using LewissBackend.API.Controller;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;

public class NetlifyControllerTests
{
    private readonly ITestOutputHelper _logger;
    public NetlifyControllerTests(ITestOutputHelper logger)
    {
        _logger = logger;
    }

    public async Task RequestHandler_ValidGetItemAction_ReturnsRequestedItem()
    {
        var netlifyController = new NetlifyController();
        var cancellationToken = new CancellationToken();

        var jsonBody = new System.Text.Json.JsonElement
        {

        };

        var response = await netlifyController.RequestHandler(jsonBody, cancellationToken);

        Assert.NotNull(response);
        var result = Assert.IsType<OkObjectResult>(response);

    }

}