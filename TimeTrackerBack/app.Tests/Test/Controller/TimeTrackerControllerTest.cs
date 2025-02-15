using app.Controllers;
using app.Services.Interfaces;
using app.Tests.Test.Mocks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace app.Tests.Test.Controller;

[TestFixture]
public class TimeTrackerControllerTest
{
    private Mock<ITimeTrackerService> _timeTrackerService;
    private Mock<IMapper> _mapperMock;
    private TimeTrackerController _controller;

    [SetUp]
    public void Setup()
    {
        _timeTrackerService = new();
        _mapperMock = new();
        _controller = new TimeTrackerController(_timeTrackerService.Object);
    }

    [Test]
    public async Task Should_Create_Time_Tracker_Status_Code_201()
    {
        //Arrange
        var inputTimeBank = MockTimebank.ListTimeBanks().First();

        _timeTrackerService
            .Setup(s => s.CreateTimeTracker(inputTimeBank))
            .ReturnsAsync(inputTimeBank);

        //Act
        var postResult = await _controller.CreateTimebanck(inputTimeBank) as ObjectResult;

        //Assert
        ClassicAssert.IsNotNull(postResult);
        ClassicAssert.AreEqual(201, postResult.StatusCode);
    }
}