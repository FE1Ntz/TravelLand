using System.Text;
using Newtonsoft.Json;
using TravelLand.Entities.Models;

namespace TravelLand.Services;

public class OrderService : HttpServiceBase
{
    protected sealed override string _apiControllerName { get; set; }
    
    public OrderService(IConfiguration configuration) : base(configuration)
    {
        _apiControllerName = "Order";
    }

    public async Task<IEnumerable<OrderModel>> GetAll()
    {
        var result = await _client.GetAsync(Url("GetAll"));
        if (!result.IsSuccessStatusCode || string.IsNullOrEmpty(result.Content.ToString()))
            return new List<OrderModel>();
        return await DeserializeFromStream<IEnumerable<OrderModel>>(result.Content);
    }
    
    public async Task<OrderModel> GetById(Guid id) 
    {
        var result = await _client.GetAsync(Url($"GetById?id={id}"));
        if (!result.IsSuccessStatusCode || string.IsNullOrEmpty(result.Content.ToString()))
            return null;
        return await DeserializeFromStream<OrderModel>(result.Content);
    }
    
    public async Task<bool> Create(OrderModel model)
    {
        if (model == null)
            return false;
        var result = await _client.PostAsync(Url("Create"),
            new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
        return result.IsSuccessStatusCode;
    }
    
    public async Task<bool> Update(OrderModel model)
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