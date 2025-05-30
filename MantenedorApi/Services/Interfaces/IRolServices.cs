using MantenedorApi.DTOs;
using MantenedorApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MantenedorApi.Services.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<Rol>> GetAllRolsAsync();
        Task<Rol> GetRolByIdAsync(int id);
        Task<Rol> CreateRolAsync(CreateRolDTO rol);
        Task<Rol> UpdateRolAsync(int id, UpdateRolDTO rol);
        Task<bool> DeleteRolAsync(int id);
    }
}
