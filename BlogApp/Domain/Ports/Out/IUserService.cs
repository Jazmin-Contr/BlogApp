using BlogApp.Application.DTOs.Auth;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task ChangeRoleAsync(int userId, string role);
}
