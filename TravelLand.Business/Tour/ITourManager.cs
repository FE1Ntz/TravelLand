using TravelLand.Entities.Models;

namespace TravelLand.Business.Tour;

public interface ITourManager
{
    Task<IEnumerable<TourModel>> GetAll();
    Task<TourModel> GetById(Guid id);
    Task<bool> Update(TourModel model);
    Task<bool> Create(TourModel model);
    Task<bool> Delete(Guid id);
}