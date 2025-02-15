using app.Controllers;
using app.Services.Interfaces;
using app.Tests.Test.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace app.Tests.Test.Controller;

public class TimeTrackerControllerTest
{
    //private readonly Mock<ITimeTrackerService> _timeTrackerService;
    //private readonly TimeTrackerController _controller;

    //public TimeTrackerControllerTest()
    //{
    //    _timeTrackerService = new();
    //    _controller = new TimeTrackerController(_timeTrackerService.Object);
    //}

    //[Fact]
    //private async Task Should_Create_Time_Tracker_Status_Code_201()
    //{
    //    //Arrange
    //    var inputTimeBank = MockTimebank.ListTimeBankInputs().First();

    //    _timeTrackerService
    //        .Setup(s => s.CreateTimeTracker(inputTimeBank))
    //        .ReturnsAsync(true);

    //    //Act
    //    var postResult = await _controller.CreateTimebanck(inputTimeBank);

    //    //Assert
    //    Assert.True(postResult is OkResult);
    //}
}