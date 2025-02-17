using app.Controllers;
using app.Services.Interfaces;
using app.Tests.Test.Mocks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Net;

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
    public async Task Should_Create_Time_Tracker_Status_Code_201_Created()
    {
        //Arrange
        var inputTimeBank = MockTimebank.ListTimeBanks().First();

        _timeTrackerService
            .Setup(s => s.CreateTimeTracker(inputTimeBank))
            .ReturnsAsync(inputTimeBank);

        //Act
        var postResult = await _controller.CreateTimebanck(inputTimeBank) as CreatedAtActionResult;

        //Assert
        ClassicAssert.IsNotNull(postResult);
        ClassicAssert.AreEqual(201, postResult.StatusCode);
    }

        [Test]
        public async Task Should_Time_Tracker_Status_Code_400_BadRequest()
        {
            //Arrange
            var inputTimeBank = MockTimebank.ListTimeBanks().First();

            var expectedMessage = "Clock-in data is missing.";

        _timeTrackerService
                .Setup(s => s.CreateTimeTracker(inputTimeBank))
                .ThrowsAsync(new ArgumentNullException("Clock-in data is missing."));

            //Act
            var result = await _controller.CreateTimebanck(inputTimeBank) as BadRequestObjectResult;

            //Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(400, result.StatusCode);
            ClassicAssert.True(result.Value.ToString().Contains(expectedMessage));
            ClassicAssert.AreEqual("Value cannot be null. (Parameter 'Clock-in data is missing.')", result.Value);
        }

        [Test]
        public async Task Should_Time_Tracker_Status_Code_409_Conflict()
        {
            //Arrange
            var inputTimeBank = MockTimebank.ListTimeBanks().First();

            var expectedMessage = "A time entry already exists for this date.";

            _timeTrackerService
                    .Setup(s => s.CreateTimeTracker(inputTimeBank))
                    .ThrowsAsync(new InvalidOperationException("A time entry already exists for this date."));

            //Act
            var result = await _controller.CreateTimebanck(inputTimeBank) as ConflictObjectResult;

            //Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(409, result.StatusCode);
            ClassicAssert.True(result.Value.ToString().Contains(expectedMessage));
        }
}