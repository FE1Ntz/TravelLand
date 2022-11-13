using Microsoft.AspNetCore.Mvc;
using TravelLand.API.Authorization;
using TravelLand.Business.User;
using TravelLand.Entities.Models;
using TravelLand.Utils.Auth;
using System.Collections.Generic;
using System.Linq;

namespace TravelLand.API.Controllers;

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IUserManager _userManager;
        private readonly JwtTokenManager _tokenManager;

        public AuthController(IUserManager userManager, JwtTokenManager tokenManager)
        {
            _userManager = userManager;
            _tokenManager = tokenManager;
        }
        
        [HttpPost("Register")]
        public async Task<ActionResult<UserModel>> Register(UserRegisterDto request)
        {
            var user = await _userManager.GetByUsername(request.Username);
            
            if (user != null)
                return BadRequest("User is already exists");
            
            PasswordHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var userModel = new UserModel
            {
                Username = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = "Client",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            await _userManager.Create(userModel);

            return Ok(userModel);
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDto request)
        {
            var user = await _userManager.GetByUsername(request.Username);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!PasswordHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            var token = await _tokenManager.CreateToken(user);

            /*var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);*/

            return Ok(token);
        }
    }

