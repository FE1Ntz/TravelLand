using TravelLand.Entities.Models;

namespace TravelLand.Business.User;

public interface IUserManager
{
    Task<IEnumerable<UserModel>> GetAll();
    Task<UserModel> GetById(Guid id);
    Task<bool> Update(UserModel model);
    Task<bool> Create(UserModel model);
    Task<bool> Delete(Guid id);
}