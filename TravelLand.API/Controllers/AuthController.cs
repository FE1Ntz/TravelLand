using Microsoft.AspNetCore.Mvc;
using TravelLand.API.Authorization;
using TravelLand.Business.User;
using TravelLand.Entities.Models;
using TravelLand.Utils.Auth;

namespace TravelLand.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IUserManager _userManager;

        public AuthController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        
        [HttpPost("Register")]
        public async Task<ActionResult<UserModel>> Register(UserLoginDto request)
        {
            PasswordHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var userModel = new UserModel()
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            await _userManager.Create(userModel);

            return Ok(userModel);
        }
        
        /*[HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User not found.");
            }

            if (!PasswordHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            var token = JwtTokenManager.CreateToken(user);

            /*var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);#1#

            return Ok(token);
        }*/
    }

