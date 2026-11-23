using System.Text.Json;
using FluentResults;
using LewissBackend.API.Model.DTO;
using LewissBackend.API.Model.Entity;
using LewissBackend.API.Service;
using Microsoft.AspNetCore.Mvc;
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

        var itemId = 12345;

        var payload = new DownloadJsonAction()
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