using Microsoft.AspNetCore.Mvc;
using TravelLand.Business.User;
using TravelLand.Entities.Models;

namespace TravelLand.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _userManager.GetAll();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("GetByUsername")]
    public async Task<IActionResult> GetByUsername(string username)
    {
        try
        {
            var result = await _userManager.GetByUsername(username);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(UserModel user)
    {
        try
        {
            var result = await _userManager.Update(user);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
}