using app.Controllers;
using app.Models.DTO;
using app.Services.Interfaces;
using app.Tests.Test.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace app.Tests.Test.Controller;

[TestFixture]
public class TimeTrackerControllerTest
{
    private Mock<ITimeTrackerService> _timeTrackerService;
    private TimeTrackerController _controller;

    [SetUp]
    public void Setup()
    {
        _timeTrackerService = new();
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
        var postResult = await _controller.CreateTimebank(inputTimeBank) as CreatedAtActionResult;

        //Assert
        ClassicAssert.IsNotNull(postResult);
        ClassicAssert.AreEqual(201, postResult.StatusCode);
    }

        [Test]
        public async Task Should_Time_Tracker_Status_Code_400_BadRequest()
        {
            //Arrange
            var inputTimeBank = MockTimebank.ListTimeBanks().First();

            var expectedMessage = "data is missing.";

            _timeTrackerService
                .Setup(s => s.CreateTimeTracker(inputTimeBank))
                .ThrowsAsync(new ArgumentNullException(nameof(inputTimeBank.StartTime), message: expectedMessage));

            //Act
            var result = await _controller.CreateTimebank(inputTimeBank) as BadRequestObjectResult;

            //Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(400, result.StatusCode);
            ClassicAssert.AreEqual($"{expectedMessage} (Parameter '{nameof(inputTimeBank.StartTime)}')", result.Value);
        }

        [Test]
        public async Task Should_Time_Tracker_Status_Code_409_Conflict()
        {
            //Arrange
            var inputTimeBank = MockTimebank.ListTimeBanks().First();

            var expectedMessage = "A time entry already exists for this date.";

            _timeTrackerService
                    .Setup(s => s.CreateTimeTracker(inputTimeBank))
                    .ThrowsAsync(new InvalidOperationException(expectedMessage));

            //Act
            var result = await _controller.CreateTimebank(inputTimeBank) as ConflictObjectResult;

            //Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(409, result.StatusCode);
            ClassicAssert.AreEqual(expectedMessage, result.Value);
    }
}