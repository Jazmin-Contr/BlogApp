using Microsoft.AspNetCore.Mvc;
using BlogApp.Application.Interfaces;

namespace BlogApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // ADMIN
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    // ADMIN → cambiar rol
    [HttpPut("{id}/role")]
    public async Task<IActionResult> ChangeRole(int id, [FromBody] string role)
    {
        await _userService.ChangeRoleAsync(id, role);
        return NoContent();
    }
}
