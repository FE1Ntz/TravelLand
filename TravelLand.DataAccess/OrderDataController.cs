using Microsoft.Extensions.Configuration;
using TravelLand.Entities.Models;

namespace TravelLand.DataAccess;

public class OrderDataController : DataController
{
    public OrderDataController(IConfiguration configuration) : base(configuration, "Orders")
    {
    }

    public Task<IEnumerable<OrderModel>> GetAll()
    {
        return GetManyAsync<OrderModel>("GetAll");
    }

    public Task<OrderModel> GetById(Guid id)
    {
        return GetOneAsync<OrderModel>("GetById", new { Id = id });
    }

    public Task<bool> Update(OrderModel model)
    {
        return PerformNonQuery("Update", model);
    }

    public Task<bool> Create(OrderModel model)
    {
        return PerformNonQuery("Create", model);
    }

    public Task<bool> Delete(Guid id)
    {
        return PerformNonQuery("Delete", new { Id = id });
    }
}