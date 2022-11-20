using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TravelLand.Entities.Models;
using TravelLand.Entities.Models.DtoModels;
using TravelLand.Entities.Models.ErrorModels;
using TravelLand.Pages;

namespace TravelLand.Services;

public class AuthService : HttpServiceBase
    {
        protected sealed override string _apiControllerName { get; set; }

        public AuthService(IConfiguration configuration) : base(configuration)
        {
            _apiControllerName = "Auth";
        }

        public async Task<AuthorizationResponceModel> Login(UserLoginDto obj)
        {
            if (obj == null)
                return new AuthorizationResponceModel();
            var response = await _client.PostAsync(Url("Login"), 
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
            var responseModel = JsonConvert.DeserializeObject<AuthorizationResponceModel>(await response.Content.ReadAsStringAsync());
            return responseModel;
        }
        
        public async Task<AuthorizationResponceModel> Register(UserRegisterDto obj)
        {
            if (obj == null)
                return new AuthorizationResponceModel();
            var response = await _client.PostAsync(Url("Register"), 
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
            var responseModel = JsonConvert.DeserializeObject<AuthorizationResponceModel>(await response.Content.ReadAsStringAsync());
            return responseModel;
        } 
    }