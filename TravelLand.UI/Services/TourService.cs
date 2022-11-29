using Newtonsoft.Json;
using System.Text;
using TravelLand.Entities.Models;

namespace TravelLand.Services; 

public class TourService : HttpServiceBase
{
    protected sealed override string _apiControllerName { get; set; }
    
    public TourService(IConfiguration configuration) : base(configuration)
    {
        _apiControllerName = "Tour";
    }

    public async Task<IEnumerable<TourModel>> GetAll()
    {
        var result = await _client.GetAsync(Url("GetAll"));
        if (!result.IsSuccessStatusCode || string.IsNullOrEmpty(result.Content.ToString()))
            return new List<TourModel>();
        return await DeserializeFromStream<IEnumerable<TourModel>>(result.Content);
    }
    
    public async Task<TourModel> GetById(Guid id) 
    {
        var result = await _client.GetAsync(Url($"GetById?id={id}"));
        if (!result.IsSuccessStatusCode || string.IsNullOrEmpty(result.Content.ToString()))
            return null;
        return await DeserializeFromStream<TourModel>(result.Content);
    }
    
    public async Task<bool> Create(TourModel model)
    {
        if (model == null)
            return false;
        var result = await _client.PostAsync(Url("Create"),
            new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
        return result.IsSuccessStatusCode;
    }
    
    public async Task<bool> Update(TourModel model)
    {
        if (model == null)
            return false;
        var result = await _client.PostAsync(Url("Update"),
            new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
        return result.IsSuccessStatusCode;
    }
    
    public async Task<bool> Delete(Guid id)
    {
        var result = await _client.GetAsync(Url($"Delete?id={id}"));
        return result.IsSuccessStatusCode;
    }
}