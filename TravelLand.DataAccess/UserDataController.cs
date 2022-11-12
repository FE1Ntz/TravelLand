using Microsoft.Extensions.Configuration;
using TravelLand.Entities.Models;

namespace TravelLand.DataAccess;

public class UserDataController : DataController
{
    public UserDataController(IConfiguration configuration) : base(configuration, "Users")
    {
    }

    public Task<IEnumerable<UserModel>> GetAll()
    {
        return GetManyAsync<UserModel>("GetAll");
    }

    public Task<UserModel> GetById(Guid id)
    {
        return GetOneAsync<UserModel>("GetById", new { Id = id });
    }

    public Task<bool> Update(UserModel model)
    {
        return PerformNonQuery("Update", model);
    }

    public Task<bool> Create(UserModel model)
    {
        return PerformNonQuery("Create", model);
    }

    public Task<bool> Delete(Guid id)
    {
        return PerformNonQuery("Delete", new { Id = id });
    }
}