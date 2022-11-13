using System.Text;
using Newtonsoft.Json;
using TravelLand.Entities.Models;
using TravelLand.Pages;

namespace TravelLand.Services;

public class AuthService : HttpServiceBase
    {
        protected sealed override string _apiControllerName { get; set; }

        public AuthService(IConfiguration configuration) : base(configuration)
        {
            _apiControllerName = "Auth";
        }

        public async Task<string> Login(UserLoginDto obj)
        {
            if (obj == null)
                return "";
            var result = await _client.PostAsync(Url("Login"), 
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
            if (!result.IsSuccessStatusCode || string.IsNullOrEmpty(result.Content.ToString()))
                return null;
            return await result.Content.ReadAsStringAsync();
        } 
    }