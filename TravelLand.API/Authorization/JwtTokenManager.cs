using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TravelLand.Business.User;
using TravelLand.Entities.Models;

namespace TravelLand.API.Authorization;

public class JwtTokenManager
{
    private static IConfiguration _configuration;
    private readonly IUserManager _userManager;

    public JwtTokenManager(IConfiguration configuration, IUserManager userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<string> CreateToken(UserModel model)
    {
        var claims = new List<Claim>();
        var user = await _userManager.GetByUsername(model.Username);
        if (user == null)
            return "";
        switch (user.Role)
        {
            case "Admin":
                claims = new List<Claim>
                {
                    new(ClaimTypes.Name, model.Username),
                    new(ClaimTypes.Role, "Admin")
                };
                break;
            case "Client":
                claims = new List<Claim>
                {
                    new(ClaimTypes.Name, model.Username),
                    new(ClaimTypes.Role, "Client")
                };
                break;
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}