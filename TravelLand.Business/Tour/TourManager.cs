using Microsoft.Extensions.Configuration;
using TravelLand.DataAccess;
using TravelLand.Entities.Models;

namespace TravelLand.Business.Tour; 

public class TourManager : ITourManager
{

    private readonly TourDataController _dataController;

    public TourManager(IConfiguration configuration)
    {
        _dataController = new TourDataController(configuration);
    }
    
    public Task<IEnumerable<TourModel>> GetAll()
    {
        return _dataController.GetAll();
    }

    public Task<TourModel> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(TourModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Create(TourModel model)
    {
        model.Id = Guid.NewGuid();
        model.StartDate.ToString("yyyy-MM-dd");
        model.EndDate.ToString("yyyy-MM-dd");
        return await _dataController.Create(model);
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}