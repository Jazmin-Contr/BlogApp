using BlogApp.Application.DTOs.Auth;
using BlogApp.Application.Interfaces;
using BlogApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        return await _context.Users
            .Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role,
                IsActive = u.IsActive
            })
            .ToListAsync();
    }

    public async Task ChangeRoleAsync(int userId, string role)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) throw new Exception("User not found");

        user.Role = role;
        await _context.SaveChangesAsync();
    }
}
