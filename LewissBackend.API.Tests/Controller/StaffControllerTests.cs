using LewissBackend.API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;

namespace LewissBackend.API.Tests.Controller;

public class StaffControllerTests
{
    private readonly ITestOutputHelper _logger;
    public StaffControllerTests(ITestOutputHelper testOutputHelper)
    {
        _logger = testOutputHelper;
    }

    [Fact]
    public async Task GetStaff_ReturnsList_WhenCalled()
    {
        var staffController = new StaffController();

        var result = await staffController.GetStaff();

        Assert.NotNull(result);
        var okObjectResult = Assert.IsType<OkObjectResult>(result);

        Assert.Equal(okObjectResult.StatusCode, StatusCodes.Status200OK);

        var value = okObjectResult.Value;

        var list = Assert.IsType<List<string>>(value);
        Assert.NotEmpty(list);




    }

}