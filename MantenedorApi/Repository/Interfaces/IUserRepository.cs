using MantenedorApi.DTOs;
using MantenedorApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MantenedorApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(CreateUserDTO user);
        Task<User> UpdateUserAsync(int id, UserUpdateDTO user);
        Task<bool> DeleteUserAsync(int id);
    }
}
