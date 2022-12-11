using Microsoft.AspNetCore.Mvc;
using TravelLand.Business.Order;
using TravelLand.Entities.Models;

namespace TravelLand.API.Controllers;

[Route("[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderManager _orderManager;

    public OrderController(IOrderManager orderManager)
    {
        _orderManager = orderManager;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _orderManager.GetAll();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var result = await _orderManager.GetById(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] OrderModel model)
    {
        try
        {
            var result = await _orderManager.Create(model);
            return result ? NoContent() : BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] OrderModel model)
    {
        try
        {
            var result = await _orderManager.Update(model);
            return result ? NoContent() : BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("Delete")]
    public async Task<IActionResult> Delete(Guid tourId, string username, bool isPaid)
    {
        try
        {
            var result = await _orderManager.Delete(tourId, username, isPaid);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
    
    [HttpGet("GetUserHistoryByUserUsername")]
    public async Task<IActionResult> GetUserHistoryByUserUsername(string username, bool isPaid)
    {
        try
        {
            var result = await _orderManager.GetUserHistoryByUserUsername(username, isPaid);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }
}