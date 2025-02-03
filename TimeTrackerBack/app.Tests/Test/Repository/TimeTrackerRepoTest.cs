using app.Entities;
using app.Infrastructure;
using app.Repository;
using app.Tests.Test.Mocks;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace app.Tests.Test.Repository
{
    public class TimeTrackerRepoTest
    {
        /*private readonly TimeTrackerRepo _repoMock; // Isolando a repo
        private readonly Mock<TimeTrackerContext> _contextMock; //Mock da context

        public TimeTrackerRepoTest()
        {
            var mockDbSet = new Mock<DbSet<TimeBank>>();

            DateTimeOffset dateTimeOffset = DateTimeOffset.Now;

            _contextMock = new();

            _repoMock = new TimeTrackerRepo(_contextMock.Object);

            var timeBank = new List<TimeBank>
            {
                new TimeBank {
                    TimebankId = 1,
                    TimeData  = dateTimeOffset.ToString("d"),
                    StartTime = dateTimeOffset.ToString("t"),
                    BreakTime = dateTimeOffset.ToString("t"),
                    Clockin = dateTimeOffset.ToString("t"),
                    Clockout = dateTimeOffset.ToString("t")
                }
            }.AsQueryable();

            mockDbSet.As<IQueryable<TimeBank>>().Setup(m => m.Provider).Returns(timeBank.Provider);
            mockDbSet.As<IQueryable<TimeBank>>().Setup(m => m.Expression).Returns(timeBank.Expression);
            mockDbSet.As<IQueryable<TimeBank>>().Setup(m => m.ElementType).Returns(timeBank.ElementType);
            mockDbSet.As<IQueryable<TimeBank>>().Setup(m => m.GetEnumerator()).Returns(timeBank.GetEnumerator);

            _contextMock
                .Setup(m => m.TimeBanks)
                .Returns(mockDbSet.Object);
        }

        [Fact]
        private async Task Should_Create_Time_Tracking()
        {
            //Arrange
            var newTimeBank = new TimeBank
            {
                TimebankId = 2,
                TimeData = DateTimeOffset.Now.AddDays(1).ToString("d"),
                StartTime = DateTimeOffset.Now.ToString("t"),
                BreakTime = DateTimeOffset.Now.ToString("t"),
                Clockin = DateTimeOffset.Now.ToString("t"),
                Clockout = DateTimeOffset.Now.ToString("t")
            };

            //Act
            bool result = await _repoMock.AddTimeTracker(newTimeBank);

            //Assert
            Assert.True(result);
        }

        [Fact]
        private async Task Should_NotCreate_Time_Tracking()
        {
            //Arrange
            var timeBank = MockTimebank.TimeBanks();

            //Act
            bool result = await _repoMock.AddTimeTracker(timeBank);

            //Assert
            Assert.False(result);
        }

        [Fact]
        private void Should_Get_Time_Tracking()
        {
            //Arrange
            DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
            var date = dateTimeOffset.ToString("d");

            //Act
            var result = _repoMock.GetTimeTracking(date);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        private void Should_Get_Time_Tracking_With_Null()
        {
            //Arrange
            var date = "2024-10-01";

            //Act
            var result = _repoMock.GetTimeTracking(date);

            //Assert
            Assert.Empty(result);
        }*/
    }
}