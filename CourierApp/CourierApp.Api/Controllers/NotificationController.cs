using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourierApp.Domain.Entities;
using CourierApp.infrastructure.Context;

namespace CourierApp.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly CourierAppContext _context;

    public NotificationController(CourierAppContext context)
    {
        _context = context;
    }

    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll(string filter = "")
    {

        var entities = await _context.Notifications.ToListAsync();



        var list = entities.Select(entity => new NotificationDtos
        {
            Id = entity.Id,
            Message = entity.Message,
            UserId = entity.UserId,
            CreatedAt = entity.CreatedAt,
        }).ToList();

        return Ok(list);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var entitydb = await _context.Notifications.FindAsync(id);
        if (entitydb == null)
        {
            return BadRequest("Not found");
        }

        var entity = new NotificationDtos
        {
            Id = entitydb.Id,
            Message = entitydb.Message,
            UserId = entitydb.UserId,
            CreatedAt = entitydb.CreatedAt,
        };

        return Ok(entity);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Create([FromBody] NotificationDtos dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The entity is invalid");
        }

        
        var entity = new Notification
        {
            Id = dto.Id,
            Message = dto.Message,
            UserId = dto.UserId,
            CreatedAt = dto.CreatedAt,
        };

        _context.Notifications.Add(entity);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Created successfully!" });
    }

    [HttpPut(nameof(Update))]
    public async Task<IActionResult> Update([FromBody] NotificationDtos dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The entity is invalid");
        }

        var entity = new Notification
        {
            Id = dto.Id,
            Message = dto.Message,
            UserId = dto.UserId,
            CreatedAt = dto.CreatedAt,
        };

        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EstudianteExists(entity.Id))
            {
                return BadRequest("Not found");
            }
            else
            {
                throw;
            }
        }

        return Ok(new { success = true, message = "Updated successfully!" });
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entityDb = await _context.Notifications.FindAsync(id);
        if (entityDb == null)
        {
            return BadRequest("Not found");
        }

        _context.Notifications.Remove(entityDb);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Deleted successfully!" });
    }

    private bool EstudianteExists(int id)
    {
        return _context.Notifications.Any(e => e.Id == id);
    }
}

