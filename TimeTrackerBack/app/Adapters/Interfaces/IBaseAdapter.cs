using app.Entities;
using app.Models;

namespace app.Adapters.Interfaces;

public interface IBaseAdapter
{
    IEnumerable<TimeBankModel> MapEntityToModel(object entityOrList);
    TimeBank MapModelToEntity(TimeBankModel timeBankModels);
}