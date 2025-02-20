using app.Models.DTO;
using app.Models.Entities;
using app.Repository.Interfaces;
using app.Services;
using app.Tests.Test.Mocks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;


namespace app.Tests.Test.Services;

[TestFixture]
public class TimeTrackServiceTest
{
    private Mock<ITimeTrackerRepo> _timeTrackerRepoMock;
    private Mock<IMapper> _mapperMock;
    private TimeTrackerService _service;

    [SetUp]
    public void Setup()
    {
        _timeTrackerRepoMock = new();
        _mapperMock = new();
        _service = new TimeTrackerService(_timeTrackerRepoMock.Object, _mapperMock.Object);
    }

    [Test]
    public async Task Should_Create_TimeTracker()
    {
        //Arrange
        var timeBank = MockTimebank.ListTimeBanks().First();
        var timeBankInput = MockTimebank.ListTimeBanksDto().First();

        _mapperMock
            .Setup(mapper => mapper.Map<TimeBank>(timeBankInput))
            .Returns(timeBank);

        _timeTrackerRepoMock
            .Setup(repo => repo.TimeEntryExistsAsync(It.IsAny<TimeBank>()))
            .ReturnsAsync(false);

        _timeTrackerRepoMock
            .Setup(repo => repo.AddTimeTracker(It.IsAny<TimeBank>()))
            .ReturnsAsync(timeBank);

        _mapperMock
            .Setup(mapper => mapper.Map<TimeBankDto>(timeBank))
            .Returns(timeBankInput);

        //Act
        var result = await _service.CreateTimeTracker(timeBankInput);

        //Assert
        ClassicAssert.IsNotNull(result);
        ClassicAssert.AreEqual(timeBankInput, result);
    }

    [Test]
    public void Should_ValidateTimeBankDto_Exception()
    {
        //Arrange
        var timeBankInput = MockTimebank.ListTimeBanksDto().First();

        timeBankInput.StartTime = "";

        var expectedMessage = "data is missing. (Parameter 'StartTime')";

        _timeTrackerRepoMock
            .Setup(repo => repo.TimeEntryExistsAsync(It.IsAny<TimeBank>()))
            .ReturnsAsync(false);
       
        //Act
        var exception = Assert.ThrowsAsync<ArgumentNullException>( async () => 
        {
            await _service.CreateTimeTracker(timeBankInput);
        });

        //Assert
        Assert.That($"{exception.Message}", Is.EqualTo(expectedMessage));
        Assert.That(exception.ParamName, Is.EqualTo("StartTime"));

    }


    [Test]
    public void Should_TimeEntryExists_Exception()
    {
        //Arrange
        var timeBankInput = MockTimebank.ListTimeBanksDto().First();

        var expectedMessage = "A time entry already exists for this date.";

        _timeTrackerRepoMock
            .Setup(repo => repo.TimeEntryExistsAsync(It.IsAny<TimeBank>()))
            .ReturnsAsync(true);

        //Act
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            await _service.CreateTimeTracker(timeBankInput);
        });

        //Assert
        Assert.That($"{exception.Message}", Is.EqualTo(expectedMessage));

    }

}