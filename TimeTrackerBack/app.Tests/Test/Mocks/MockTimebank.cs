using app.Entities;
using app.Models;

namespace app.Tests.Test.Mocks;

internal class MockTimebank
{
    public static IEnumerable<TimeBank> ListTimeBanks()
    {
        DateTimeOffset dateTimeOffset = DateTimeOffset.Now;

        var timeBanks = new List<TimeBank>
    {
        new TimeBank
        {
            TimebankId = 1,
            TimeData = dateTimeOffset.Date,
            StartTime = dateTimeOffset.ToString("t"),
            BreakTime = dateTimeOffset.ToString("t"),
            Clockin = dateTimeOffset.ToString("t"),
            Clockout = dateTimeOffset.ToString("t"),
            Description = "Teste do texto 1"
        },
        new TimeBank
        {
            TimebankId = 2,
            TimeData = dateTimeOffset.Date.AddDays(1),
            StartTime = dateTimeOffset.AddHours(1).ToString("t"),
            BreakTime = dateTimeOffset.AddHours(1).ToString("t"),
            Clockin = dateTimeOffset.AddHours(1).ToString("t"),
            Clockout = dateTimeOffset.AddHours(1).ToString("t"),
            Description = "Teste do texto 2"
        },
        new TimeBank
        {
            TimebankId = 3,
            TimeData = dateTimeOffset.Date.AddDays(2),
            StartTime = dateTimeOffset.AddHours(2).ToString("t"),
            BreakTime = dateTimeOffset.AddHours(2).ToString("t"),
            Clockin = dateTimeOffset.AddHours(2).ToString("t"),
            Clockout = dateTimeOffset.AddHours(2).ToString("t"),
            Description = "Teste do texto 3"
        }
        // Adicione mais instâncias se necessário
    };

        return timeBanks;
    }


    public static IEnumerable<TimeBankModel> ListTimeBankInputs()
    {
        DateTimeOffset dateTimeOffset = DateTimeOffset.Now;

        var timeBanks = new List<TimeBankModel>
    {
        new TimeBankModel
        {
            TimeData = dateTimeOffset.Date,
            StartTime = dateTimeOffset.ToString("t"),
            BreakTime = dateTimeOffset.ToString("t"),
            Clockin = dateTimeOffset.ToString("t"),
            Clockout = dateTimeOffset.ToString("t"),
            Description = "Teste do texto 1"
        },
        new TimeBankModel
        {
            TimeData = dateTimeOffset.Date.AddDays(1),
            StartTime = dateTimeOffset.AddHours(1).ToString("t"),
            BreakTime = dateTimeOffset.AddHours(1).ToString("t"),
            Clockin = dateTimeOffset.AddHours(1).ToString("t"),
            Clockout = dateTimeOffset.AddHours(1).ToString("t"),
            Description = "Teste do texto 2"
        },
        new TimeBankModel
        {
            TimeData = dateTimeOffset.Date.AddDays(2),
            StartTime = dateTimeOffset.AddHours(2).ToString("t"),
            BreakTime = dateTimeOffset.AddHours(2).ToString("t"),
            Clockin = dateTimeOffset.AddHours(2).ToString("t"),
            Clockout = dateTimeOffset.AddHours(2).ToString("t"),
            Description = "Teste do texto 3"
        }
    };

        return timeBanks;
    }
}