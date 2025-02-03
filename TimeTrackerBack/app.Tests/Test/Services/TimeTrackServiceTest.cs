using app.Adapters.Interfaces;
using app.Repository.Interfaces;
using app.Services;
using app.Services.Interfaces;
using app.Tests.Test.Mocks;
using Moq;


namespace app.Tests.Test.Services;

public class TimeTrackServiceTest
{
     private readonly Mock<ITimeTrackerRepo> _timeTrackerRepoMock;
     private readonly Mock<IBaseAdapter> _baseAdapterMock;
     private readonly ITimeTrackerService _service;

     public TimeTrackServiceTest()
     {
         _timeTrackerRepoMock = new();
         _baseAdapterMock = new();
         _service = new TimeTrackerService(_timeTrackerRepoMock.Object, _baseAdapterMock.Object);
     }

    [Fact]
    private async Task Should_Create_TimeTrackService()
    {
        //Arrange
        var timeBankInput = MockTimebank.ListTimeBankInputs();
        var timeBank = MockTimebank.ListTimeBanks().First();

        _baseAdapterMock
            .Setup(a => a.MapModelToEntity(timeBankInput.First()))
            .Returns(timeBank);

        _timeTrackerRepoMock
            .Setup(repo => repo.AddTimeTracker(timeBank))
            .ReturnsAsync(true);

        //Act
        bool result = await _service.CreateTimeTracker(timeBankInput.First());

        //Assert
        Assert.True(result);
    }

    [Fact]
    private async Task Should_NotCreate_TimeTrackService()
    {
        //Arrange
        var timeBankInput = MockTimebank.ListTimeBankInputs();
        var timeBank = MockTimebank.ListTimeBanks().First();

        _baseAdapterMock
            .Setup(a => a.MapModelToEntity(timeBankInput.First()))
            .Returns(timeBank);

        _timeTrackerRepoMock
            .Setup(repo => repo.AddTimeTracker(timeBank))
            .ReturnsAsync(false);

        //Act
        bool result = await _service.CreateTimeTracker(timeBankInput.First());

        //Assert
        Assert.False(result);
    }

    [Fact]
    private async Task Should_Get_TimeTracker_By_Month()
    {
        //Arrange
        DateTime mockMonth = new();

        var timeBankInput = MockTimebank.ListTimeBankInputs();
        var timeBank = MockTimebank.ListTimeBanks();

        _timeTrackerRepoMock
             .Setup(repo => repo.GetTimeTrackingByMonth(mockMonth))
             .ReturnsAsync(() => timeBank);

        _baseAdapterMock
            .Setup(a => a.MapEntityToModel(timeBank))
            .Returns(() => timeBankInput);

        //Act
        var result = await _service.GetTimeTrackersByMonth(mockMonth);

        //Assert
        Assert.Equal(timeBankInput, result);
        Assert.Equal(timeBankInput, result);
    }

    [Fact]
    private async Task Should_Get_TimeTrackService_By_Date()
    {
        //Arrange
       DateTime mockDate = new();

       var timeBankInput = MockTimebank.ListTimeBankInputs();
       var timeBank = MockTimebank.ListTimeBanks();

       _timeTrackerRepoMock
            .Setup(repo => repo.SelectTimeTrackingByDate(mockDate))
            .ReturnsAsync(() => timeBank);

       _baseAdapterMock
           .Setup(a => a.MapEntityToModel(timeBank))
           .Returns(() => timeBankInput);

        //Act
       var result = await _service.GetTimeTrackersByDate(mockDate);


       //Assert
       Assert.NotNull(result);
       Assert.Equal(timeBankInput.FirstOrDefault(), result.FirstOrDefault());
    }

    /*[Fact]
     private async Task Should_Get_Empty_TimeTrackService()
     {
        //Arrange
        DateTime date = new();
         
         _timeTrackerRepoMock
             .Setup(repo => repo.SelectTimeTrackingByDate(date))
             .ReturnsAsync(() => null);
         
         //Act
         var result = await _service.GetTimeTrackersByDate(date);
         
         //Assert
         Assert.Null(result);
     }*/
}