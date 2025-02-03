using app.Adapters.Interfaces;
using app.Entities;
using app.Models;

namespace app.Adapters;

public class BaseAdapter: IBaseAdapter
{
    
    public IEnumerable<TimeBankModel> MapEntityToModel(object entityOrList)
     {
        if (entityOrList is IEnumerable<TimeBank> timeBankList)
        {
            var models = new List<TimeBankModel>();

            foreach (var entity in timeBankList)
            {
                var model = MapSingleEntityToModel(entity);
                models.Add(model);
            }

            return models;
        }
        else if(entityOrList is TimeBank timeBankEntity)
        {
            return new List<TimeBankModel> { MapSingleEntityToModel(timeBankEntity) };

        }

        throw new ArgumentException("O argumento deve ser um TimeBank ou IEnumerable<TimeBank>");

    }
    
     public TimeBank MapModelToEntity(TimeBankModel timeBankModels)
     {
         var entity = Activator.CreateInstance<TimeBank>();

         var propierties = GetProperty<TimeBank, TimeBankModel>();

         foreach (var property in propierties)
         {
             var value = timeBankModels.GetType().GetProperty(property)!.GetValue(timeBankModels);
             entity.GetType().GetProperty(property)!.SetValue(entity, value);
         }
         return entity;
     }

    private TimeBankModel MapSingleEntityToModel(TimeBank timeBankEntity)
    {
        var model = Activator.CreateInstance<TimeBankModel>();

        var prop = GetProperty<TimeBankModel, TimeBank>();

        foreach (var item in prop)
        {
            var value = timeBankEntity.GetType().GetProperty(item)!.GetValue(timeBankEntity);
            model.GetType().GetProperty(item)!.SetValue(model, value);
        }

        return model;
    }

    private static List<string> GetProperty<TFrom, TTo>()
    {
        var from = typeof(TFrom).GetProperties();
        var to = typeof(TTo).GetProperties();
        
        var properties = new List<string>();

        foreach (var item in to)
        {
            var fromProperty = from.FirstOrDefault(x => x.Name == item.Name && x.GetType() == item.GetType());
            
            if(fromProperty != null)
                properties.Add(item.Name);
        }

        return properties;
    }
}