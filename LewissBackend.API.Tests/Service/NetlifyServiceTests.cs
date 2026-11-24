using System.Text.Json;
using FluentResults;
using LewissBackend.API.Data;
using LewissBackend.API.Model.DTO;
using LewissBackend.API.Model.Entity;
using LewissBackend.API.Service;
using Moq;
using Xunit.Abstractions;

namespace LewissBackend.API.Tests.Service;


public class NetlifyServiceTests
{
    private readonly ITestOutputHelper _logger;
    public NetlifyServiceTests(ITestOutputHelper logger)
    {
        _logger = logger;
    }

    [Theory]
    [InlineData(100021)]
    [InlineData(100156)]
    public async Task GetRequestedItemAsync_ReturnsJson_ValidDownloadJsonPayload(int itemId)
    {

        var netlifyService = new NetlifyService();

        var JSONFileHandlerMock = new Mock<IJSONFileHandler>();
        JSONFileHandlerMock.Setup(x => x.GetProjectFileAsync(It.IsAny<String>())).ReturnsAsync(new ProjectFile() { Id = itemId });

        var payload = new DownloadJsonAction(JSONFileHandlerMock.Object)
        {
            itemId = itemId.ToString()
        };

        var cancellationToken = new CancellationToken();

        var result = await netlifyService.GetRequestedItemAsync(payload, cancellationToken);
        Assert.NotNull(result);

        var fluentResult = Assert.IsType<Result<JsonElement>>(result);



        Assert.True(fluentResult.IsSuccess);

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new BlindTypeSpecConverter() } };
        var project = fluentResult.Value.Deserialize<ProjectFile>(options);
        Assert.NotNull(project);

        Assert.Equal(itemId, project.Id);

    }
}