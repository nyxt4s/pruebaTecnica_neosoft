using MantenedorApi.DTOs;
using MantenedorApi.Models;
using MantenedorApi.Models.Response;

namespace MantenedorApi.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<ResponseUser> CreateUserAsync(CreateUserDTO user);

    Task<ResponseUser> UpdateUserAsync(int id, UserUpdateDTO user);
    Task<ResponseUser> DeleteUserAsync(int id);
}