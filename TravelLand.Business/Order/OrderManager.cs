using Microsoft.Extensions.Configuration;
using TravelLand.DataAccess;
using TravelLand.Entities.Models;

namespace TravelLand.Business.Order;

public class OrderManager : IOrderManager
{
    private readonly OrderDataController _dataController;

    public OrderManager(IConfiguration configuration)
    {
        _dataController = new OrderDataController(configuration);
    }

    public Task<IEnumerable<OrderModel>> GetAll()
    {
        return _dataController.GetAll();
    }

    public Task<OrderModel> GetById(Guid id)
    {
        return _dataController.GetById(id);
    }

    public async Task<bool> Update(OrderModel model)
    {
        return await _dataController.Update(model);
    }

    public async Task<bool> Create(OrderModel model)
    {
        model.Id = Guid.NewGuid();
        return await _dataController.Create(model);
    }

    public Task<bool> Delete(Guid id)
    {
        return _dataController.Delete(id);
    }
}