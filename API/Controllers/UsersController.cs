using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]


public class UsersController : ControllerBase
{
    private readonly DataContext _constext;

    public UsersController(DataContext constext)
    {
        _constext = constext;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _constext.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id}")] 
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _constext.Users.FindAsync(id);
    }
}

