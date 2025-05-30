using System.Collections.Generic;
using System.Threading.Tasks;
using MantenedorApi.DTOs;
using MantenedorApi.Models;

namespace MantenedorApi.Repository.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol> GetByIdAsync(int id);
        Task<Rol> CreateAsync(CreateRolDTO rol);
        Task<Rol> UpdateAsync(int id, UpdateRolDTO rol);
        Task<bool> DeleteAsync(int id);
    }
}