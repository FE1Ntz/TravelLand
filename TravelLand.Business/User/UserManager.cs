using Microsoft.Extensions.Configuration;
using TravelLand.DataAccess;
using TravelLand.Entities.Models;

namespace TravelLand.Business.User;

public class UserManager : IUserManager
{
    private readonly UserDataController _dataController;

    public UserManager(IConfiguration configuration)
    {
        _dataController = new UserDataController(configuration);
    }

    public Task<IEnumerable<UserModel>> GetAll()
    {
        return _dataController.GetAll();
    }

    public Task<UserModel> GetById(Guid id)
    {
        return _dataController.GetById(id);
    }

    public Task<bool> Update(UserModel model)
    {
        return _dataController.Update(model);
    }

    public async Task<bool> Create(UserModel model)
    {
        model.Id = Guid.NewGuid();
        return await _dataController.Create(model);
    }

    public Task<bool> Delete(Guid id)
    {
        return _dataController.Delete(id);
    }

    public Task<UserModel> GetByUsername(string username)
    {
        return _dataController.GetByUsername(username);
    }
}