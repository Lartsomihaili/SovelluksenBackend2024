using sovelluksenbackend.Models;

namespace Backend2024.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO?> GetUserAsync(string username); 
        Task<UserDTO?> NewUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(string username);

    }
}