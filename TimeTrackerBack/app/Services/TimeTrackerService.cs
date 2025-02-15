using app.Models.DTO;
using app.Models.Entities;
using app.Repository.Interfaces;
using app.Services.Interfaces;
using AutoMapper;

namespace app.Services;

public class TimeTrackerService(
    ITimeTrackerRepo repo,
    IMapper iMapper
    ): ITimeTrackerService
{
    //TODO incluir no futuro badrequest, talves m[a formatacao.
    public async Task<TimeBankDto> CreateTimeTracker(TimeBankDto timeBankDto)
    {
        var timeBank = iMapper.Map<TimeBank>(timeBankDto);

        var addTime = await repo.AddTimeTracker(timeBank)
            ?? throw new InvalidOperationException();

        var response = iMapper.Map<TimeBankDto>(addTime);

        return response;

    }
}