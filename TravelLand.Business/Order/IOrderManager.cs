using TravelLand.Entities.Models;

namespace TravelLand.Business.Order;

public interface IOrderManager
{
    Task<IEnumerable<OrderModel>> GetAll();
    Task<OrderModel> GetById(Guid id);
    Task<bool> Update(OrderModel model);
    Task<bool> Create(OrderModel model);
    Task<bool> Delete(Guid tourId, string username, bool isPaid);
    Task<IEnumerable<TourModel>> GetUserHistoryByUserUsername(string username, bool isPaid);
}