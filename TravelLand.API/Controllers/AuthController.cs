using Microsoft.AspNetCore.Mvc;
using TravelLand.API.Authorization;
using TravelLand.Business.User;
using TravelLand.Entities.Models;
using TravelLand.Entities.Models.DtoModels;
using TravelLand.Entities.Models.ErrorModels;
using TravelLand.Utils.Auth;

namespace TravelLand.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtTokenManager _tokenManager;

    private readonly IUserManager _userManager;

    public AuthController(IUserManager userManager, JwtTokenManager tokenManager)
    {
        _userManager = userManager;
        _tokenManager = tokenManager;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register(UserRegisterDto request)
    {
        var user = await _userManager.GetByUsername(request.Username);

        if (user != null)
            return BadRequest(new AuthorizationResponceModel
            {
                IsSuccess = false,
                StatusCode = 400,
                Errors = new Dictionary<string, string> { { "Username", "Username already exists" } }
            });


        PasswordHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

        var userModel = new UserModel
        {
            Username = request.Username,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = "Client",
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            PhoneNumber = request.PhoneNumber,
            EmailAddress = request.EmailAddress
        };

        await _userManager.Create(userModel);

        return Ok(new AuthorizationResponceModel
        {
            IsSuccess = true,
            StatusCode = 200
        });
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(UserLoginDto request)
    {
        var user = await _userManager.GetByUsername(request.Username);
        if (user == null)
            return BadRequest(new AuthorizationResponceModel
            {
                IsSuccess = false,
                StatusCode = 400,
                Errors = new Dictionary<string, string>
                {
                    { "Username", "Username not found" },
                    { "Password", "" }
                }
            });

        if (!PasswordHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            return BadRequest(new AuthorizationResponceModel
            {
                IsSuccess = false,
                StatusCode = 400,
                Errors = new Dictionary<string, string>
                {
                    { "Username", "" },
                    { "Password", "Wrong password" }
                }
            });

        var token = await _tokenManager.CreateToken(user);

        return Ok(new AuthorizationResponceModel
        {
            IsSuccess = true,
            StatusCode = 200,
            Token = token
        });
    }
}