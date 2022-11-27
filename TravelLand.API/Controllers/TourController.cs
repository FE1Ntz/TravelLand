﻿using Microsoft.AspNetCore.Mvc;
using TravelLand.Business.Tour;
using TravelLand.Entities.Models;

namespace TravelLand.API.Controllers;

[Route("[controller]")]
[ApiController]

public class TourController : Controller {
    private readonly ITourManager _tourManager;

    public TourController(ITourManager tourManager)
    {
        _tourManager = tourManager;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _tourManager.GetAll();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] TourModel model)
    {
        try
        {
            var result = await _tourManager.Create(model);
            return result ? NoContent() : BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

}