using MantenedorApi.DTOs;
using MantenedorApi.Models;
using MantenedorApi.Models.Response;
using MantenedorApi.Repository;
using MantenedorApi.Repository.Interfaces;
using MantenedorApi.Services.Interfaces;
using MantenedorApi.Utils.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MantenedorApi.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IRolRepository _rolRepository;
        public UserService(IUserRepository userRepository, IRolRepository rolRepository)
        {
            _userRepository = userRepository;
            _rolRepository = rolRepository;
        }

        /// <summary>
        /// Crea un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="user">Objeto User con los datos del nuevo usuario.</param>
        /// <returns>El usuario creado, incluyendo su Id.</returns>
        public async Task<ResponseUser> CreateUserAsync(CreateUserDTO user)
        {
            try
            {
                ValidateData validateData = new ValidateData();
                // Validar el formato del email
                if (string.IsNullOrWhiteSpace(user.Email) || !validateData.IsValidEmail(user.Email))
                {
                    return new ResponseUser
                    {
                        Success = false,
                        Message = "No se pudo crear el usuario: el email proporcionado no es válido.",
                        User = null
                    };
                }
                // Verificar si el rol existe
                var roleExists = await _rolRepository.GetByIdAsync(user.rolId);
                if (roleExists == null)
                {
                    return new ResponseUser
                    {
                        Success = false,
                        Message = $"No se pudo crear el usuario: el rol con Id {user.rolId} no existe.",
                        User = null
                    };
                }
                // Crear el usuario si el rol es válido
                var createdUser = await _userRepository.CreateUserAsync(user);
                return new ResponseUser
                {
                    Success = true,
                    Message = "Usuario creado exitosamente.",
                    User = createdUser
                };
            }
            catch (Exception ex)
            {
                return new ResponseUser
                {
                    Success = false,
                    Message = $"Error inesperado al crear el usuario: {ex.Message}",
                    User = null
                };
            }
        }


        /// <summary>
        /// Elimina un usuario existente por su Id.
        /// </summary>
        /// <param name="id">Id del usuario a eliminar.</param>
        /// <returns>Mensaje de confirmación o resultado de la operación.</returns>
        public async Task<ResponseUser> DeleteUserAsync(int id)
        {
            try
            {
                // Validar que el usuario exista
                var userExists = await _userRepository.GetUserByIdAsync(id);
                if (userExists == null)
                {
                    return new ResponseUser
                    {
                        Success = false,
                        Message = $"No se pudo eliminar el usuario: el usuario con Id {id} no existe."
                    };
                }

                // Intentar eliminar el usuario
                var isDeleted = await _userRepository.DeleteUserAsync(id);
                if (!isDeleted)
                {
                    return new ResponseUser
                    {
                        Success = false,
                        Message = $"No se pudo eliminar el usuario con Id {id}."
                    };
                }

                // Retornar mensaje de éxito
                return new ResponseUser
                {
                    Success = true,
                    Message = $"Usuario con Id {id} eliminado exitosamente."
                };
            }
            catch (Exception ex)
            {
                return new ResponseUser
                {
                    Success = false,
                    Message = $"Error inesperado al eliminar el usuario con Id {id}: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios.
        /// </summary>
        /// <returns>Una colección enumerable de usuarios.</returns>
        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return _userRepository.GetAllUsersAsync();
        }

        /// <summary>
        /// Obtiene un usuario específico por su Id.
        /// </summary>
        /// <param name="id">Id del usuario a buscar.</param>
        /// <returns>El usuario correspondiente si existe.</returns>
        public Task<User> GetUserByIdAsync(int id)
        {
            return _userRepository.GetUserByIdAsync(id);
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        /// <param name="id">Id del usuario a actualizar.</param>
        /// <param name="user">Objeto User con los nuevos datos.</param>
        /// <returns>El usuario actualizado.</returns>
        public async Task<ResponseUser> UpdateUserAsync(int id, UserUpdateDTO user)
        {
            try
            {
                // Validar que el rol exista
                var roleExists = await _rolRepository.GetByIdAsync(user.rol);
                if (roleExists == null)
                {
                    return new ResponseUser
                    {
                        Success = false,
                        Message = $"No se pudo actualizar el usuario: el rol con Id {user.rol} no existe.",
                        User = null
                    };
                }

                // Validar que el usuario exista
                var userExists = await _userRepository.GetUserByIdAsync(id);
                if (userExists == null)
                {
                    return new ResponseUser
                    {
                        Success = false,
                        Message = $"No se pudo actualizar el usuario: el usuario con Id {id} no existe.",
                        User = null
                    };
                }

                // Actualizar el usuario
                var userUpdated = await _userRepository.UpdateUserAsync(id, user);
                if (userUpdated == null)
                {
                    return new ResponseUser
                    {
                        Success = false,
                        Message = $"No se pudo actualizar el usuario con Id {id}.",
                        User = null
                    };
                }

                // Retornar el usuario actualizado
                return new ResponseUser
                {
                    Success = true,
                    Message = "Usuario actualizado exitosamente.",
                    User = userUpdated
                };
            }
            catch (Exception ex)
            {
                return new ResponseUser
                {
                    Success = false,
                    Message = $"Error inesperado al actualizar el usuario: {ex.Message}",
                    User = null
                };
            }
        }


    }
}
