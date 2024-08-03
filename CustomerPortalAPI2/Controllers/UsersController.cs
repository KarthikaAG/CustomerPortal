using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CustomerPortalAPI2.Data;
using CustomerPortalAPI2.Models;
using System;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (await _context.Users.AnyAsync(u => u.Username == user.Username))
        {
            return BadRequest("Username already exists.");
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User login)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }

        return Ok(user);
    }

    [HttpGet("exists/{username}")]
    public async Task<IActionResult> UserExists(string username)
    {
        var exists = await _context.Users.AnyAsync(u => u.Username == username);
        return Ok(exists);
    }
}

