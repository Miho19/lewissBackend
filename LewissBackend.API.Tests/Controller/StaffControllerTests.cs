using FluentResults;
using LewissBackend.API.Controller;
using LewissBackend.API.Model.DTO;
using LewissBackend.API.Service;
using LewissBackend.API.Tests.Fixtures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
    public async Task GetStaff_ReturnsStatusCode200AndList_WhenCalled()
    {
        var staffServiceMock = new Mock<IStaffService>();
        staffServiceMock.Setup(service => service.GetStaffListAsync(It.IsAny<CancellationToken>()))
        .ReturnsAsync(Result.Ok(StaffFixture.GetStaffDTOList()));

        var staffController = new StaffController(staffServiceMock.Object);
        var cancellationToken = new CancellationToken();
        var response = await staffController.GetStaff(cancellationToken);

        Assert.NotNull(response);
        var okObjectResult = Assert.IsType<OkObjectResult>(response);

        Assert.Equal(okObjectResult.StatusCode, StatusCodes.Status200OK);

        var value = okObjectResult.Value;

        var list = Assert.IsType<List<StaffDTO>>(value);
        Assert.NotEmpty(list);

    }


    [Fact]
    public async Task GetStaff_ReturnsStatusCode204AndEmptyList_WhenCalled()
    {
        var staffServiceMock = new Mock<IStaffService>();
        staffServiceMock.Setup(service => service.GetStaffListAsync(It.IsAny<CancellationToken>()))
        .ReturnsAsync(Result.Fail("Empty List"));

        var staffController = new StaffController(staffServiceMock.Object);
        var cancellationToken = new CancellationToken();
        var response = await staffController.GetStaff(cancellationToken);

        Assert.NotNull(response);
        var okObjectResult = Assert.IsType<OkObjectResult>(response);

        Assert.Equal(okObjectResult.StatusCode, StatusCodes.Status204NoContent);

        var value = okObjectResult.Value;




    }


}