using Microsoft.Extensions.Configuration;
using TravelLand.Entities.Models;

namespace TravelLand.DataAccess;

public class TourDataController : DataController
{
    public TourDataController(IConfiguration configuration) : base(configuration, "Tours")
    {
    }

    public Task<IEnumerable<TourModel>> GetAll()
    {
        return GetManyAsync<TourModel>("GetAll");
    }

    public Task<TourModel> GetById(Guid id)
    {
        return GetOneAsync<TourModel>("GetById", new { Id = id });
    }

    public Task<bool> Update(TourModel model)
    {
        return PerformNonQuery("Update", model);
    }

    public Task<bool> Create(TourModel model)
    {
        return PerformNonQuery("Create", model);
    }

    public Task<bool> Delete(Guid id)
    {
        return PerformNonQuery("Delete", new { Id = id });
    }
}