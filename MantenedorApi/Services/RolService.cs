using MantenedorApi.DTOs;
using MantenedorApi.Models;
using MantenedorApi.Repository.Interfaces; 
using MantenedorApi.Services.Interfaces;

namespace MantenedorApi.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;

        // Inyectamos el repositorio en el constructor
        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        /// <summary>
        /// Obtiene todos los roles desde la base de datos.
        /// </summary>
        public Task<IEnumerable<Rol>> GetAllRolsAsync()
        {
            return _rolRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtiene un rol por su ID.
        /// </summary>
        public async Task<Rol> GetRolByIdAsync(int id)
        {
            var rol = await _rolRepository.GetByIdAsync(id);
            return rol; // Retorna el objeto o null si no se encuentra.

        }

        /// <summary>
        /// Crea un nuevo rol con los datos entregados.
        /// </summary>
        public async Task<Rol> CreateRolAsync(CreateRolDTO data)
        {
            try
            {
                // Llama al repositorio y espera el resultado
                var rol = await _rolRepository.CreateAsync(data);

                // Retorna el rol creado
                return rol;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción inesperada
                throw new Exception($"Error al crear el rol: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza un rol existente usando su ID y los nuevos datos.
        /// </summary>
        public Task<Rol> UpdateRolAsync(int id, UpdateRolDTO rol)
        {
            return _rolRepository.UpdateAsync(id, rol);
        }

        /// <summary>
        /// Elimina un rol por su ID.
        /// </summary>
        public Task<bool> DeleteRolAsync(int id)
        {
            return _rolRepository.DeleteAsync(id);
        }
    }
}
