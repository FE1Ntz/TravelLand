using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TravelLand.Services;

public abstract class HttpServiceBase
{
    protected HttpClient _client { get; }
    private IConfiguration _configuration { get; }
    private AuthenticationStateProvider _authenticationStateProvider { get; }
    protected abstract string _apiControllerName { get; set; }


    protected HttpServiceBase(IConfiguration configuration)
    {
        _configuration = configuration;


        if (string.IsNullOrEmpty(_configuration["WebApiUrl"]))
            return;

        _client = new HttpClient();
        _client.BaseAddress = new Uri(_configuration["WebApiUrl"]);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.Timeout = TimeSpan.FromMinutes(5);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }


    protected string Url()
    {
        return $"{_apiControllerName}";
    }

    protected string Url(string action)
    {
        return $"{_apiControllerName}/{action}";
    }

    public static async Task<T> DeserializeFromStream<T>(HttpContent content)
    {
        var value = await content.ReadAsStringAsync();
        return value.Contains("<!DOCTYPE html>") ? default : JsonConvert.DeserializeObject<T>(value);
    }
}