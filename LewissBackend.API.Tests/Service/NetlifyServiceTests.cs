using LewissBackend.API.Model.DTO;
using LewissBackend.API.Service;
using Xunit.Abstractions;

namespace LewissBackend.API.Tests.Service;


public class NetlifyServiceTests
{
    private readonly ITestOutputHelper _logger;
    public NetlifyServiceTests(ITestOutputHelper logger)
    {
        _logger = logger;
    }

    [Fact]
    public async Task GetRequestedItemAsync_ReturnsJson_ValidDownloadJsonPayload()
    {
        var netlifyService = new NetlifyService();
        var payload = new DownloadJsonAction()
        {
            itemId = "123456"
        };

        var cancellationToken = new CancellationToken();

        var result = await netlifyService.GetRequestedItemAsync(payload, cancellationToken);


        Assert.NotNull(result);

    }
}