using TravelLand.Entities.Models;

namespace TravelLand.Services; 

public class UserService : HttpServiceBase
{
    protected sealed override string _apiControllerName { get; set; }
    
    public UserService(IConfiguration configuration) : base(configuration)
    {
        _apiControllerName = "User";
    }

    public async Task<IEnumerable<UserModel>> GetAll()
    {
        var result = await _client.GetAsync(Url("GetAll"));
        if (!result.IsSuccessStatusCode || string.IsNullOrEmpty(result.Content.ToString()))
            return new List<UserModel>();
        return await DeserializeFromStream<IEnumerable<UserModel>>(result.Content);
    }
    
    public async Task<UserModel> GetByUsername(string username)
    {
        var result = await _client.GetAsync(Url($"GetByUsername?username={username}"));
        if (!result.IsSuccessStatusCode || string.IsNullOrEmpty(result.Content.ToString()))
            return null;
        return await DeserializeFromStream<UserModel>(result.Content);
    }
}