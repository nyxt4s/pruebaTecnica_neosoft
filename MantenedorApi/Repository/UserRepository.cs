using MantenedorApi.Repository.Interfaces;
using MantenedorApi.Models;
using MantenedorApi.Data;
using Dapper;
using MantenedorApi.DTOs;

namespace MantenedorApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapperContext;
        public UserRepository(DapperContext dapperContext) {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var query = @"
                        SELECT 
                            usuarios.Id AS UserId,
                            usuarios.Nombre AS UserName,
                            usuarios.Email AS UserEmail,
                            roles.Id AS RoleId,
                            roles.Nombre AS RoleName
                        FROM usuarios
                        INNER JOIN roles ON roles.Id = usuarios.rolId";

            try
            {
                using var connection = _dapperContext.CreateConnection();
                var result = await connection.QueryAsync(query);

                List<User> users = new List<User>();
                foreach (var row in result)
                {
                    User user = new User
                    {
                        Id = row.UserId,
                        Nombre = row.UserName,
                        Email = row.UserEmail,
                        rol = new Rol
                        {
                            Id = row.RoleId,
                            Nombre = row.RoleName
                        }
                    };

                    users.Add(user);
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios.", ex);
            }
        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            var query = @"
                SELECT 
                    usuarios.Id AS UserId,
                    usuarios.Nombre AS UserName,
                    usuarios.Email AS UserEmail,
                    roles.Id AS RoleId,
                    roles.Nombre AS RoleName
                FROM usuarios
                INNER JOIN roles ON roles.Id = usuarios.rolId
                WHERE usuarios.Id = @Id";

            try
            {
                using var connection = _dapperContext.CreateConnection();
                var result = await connection.QuerySingleOrDefaultAsync(query, new { Id = id });

                if (result == null)
                {
                    return null;
                }

                // Mapea los datos al modelo User
                var user = new User
                {
                    Id = result.UserId,
                    Nombre = result.UserName,
                    Email = result.UserEmail,
                    rol = new Rol
                    {
                        Id = result.RoleId,
                        Nombre = result.RoleName
                    }
                };

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el usuario con Id {id}.", ex);
            }
        }

        public async Task<User> CreateUserAsync(CreateUserDTO user)
        {
            var sql = @"INSERT INTO usuarios (Nombre, Email, rolId)
                VALUES (@Nombre, @Email, @RolId);
                SELECT LAST_INSERT_ID();";

            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    // Ejecuta la inserción y obtiene el ID generado
                    var newUserId = await connection.QuerySingleOrDefaultAsync<int>(sql, new
                    {
                        user.Nombre,
                        user.Email,
                        user.rolId
                    });

                    if (newUserId == 0)
                    {
                        throw new Exception("No se pudo crear el usuario. Verifica que los datos sean válidos.");
                    }

                    // Retorna el usuario creado con el ID generado
                    return new User
                    {
                        Id = newUserId,
                        Nombre = user.Nombre,
                        Email = user.Email,
                        rol = new Rol { Id = user.rolId } // Solo asigna el ID del rol
                    };
                }
            }
            catch (Exception ex)
            {
                // Captura otros errores inesperados
                throw new Exception($"Error inesperado al crear el usuario: {ex.Message}", ex);
            }
        }


        public async Task<User?> UpdateUserAsync(int id, UserUpdateDTO user)
        {
            var updateUserQuery = @"
                                    UPDATE usuarios
                                    SET Nombre = @Nombre, Email = @Email, rolId = @RolId
                                    WHERE Id = @Id";

                                        var getUserQuery = @"
                                    SELECT 
                                        usuarios.Id AS UserId,
                                        usuarios.Nombre AS UserName,
                                        usuarios.Email AS UserEmail,
                                        roles.Id AS RoleId,
                                        roles.Nombre AS RoleName
                                    FROM usuarios
                                    INNER JOIN roles ON roles.Id = usuarios.rolId
                                    WHERE usuarios.Id = @Id";

            try
            {
                using var connection = _dapperContext.CreateConnection();

                // Ejecutar la actualización
                var rowsAffected = await connection.ExecuteAsync(updateUserQuery, new
                {
                    Nombre = user.Nombre,
                    Email = user.Email,
                    RolId = user.rol,
                    Id = id
                });

                if (rowsAffected == 0)
                {
                    return null; // Retorna null si no se actualizó ninguna fila
                }

                // Obtener el usuario actualizado
                var result = await connection.QuerySingleOrDefaultAsync(getUserQuery, new { Id = id });

                if (result == null)
                {
                    return null; // Retorna null si no se encuentra el usuario
                }

                // Mapea los datos al modelo User
                var updatedUser = new User
                {
                    Id = result.UserId,
                    Nombre = result.UserName,
                    Email = result.UserEmail,
                    rol = new Rol
                    {
                        Id = result.RoleId,
                        Nombre = result.RoleName
                    }
                };

                return updatedUser;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al actualizar el usuario con Id {id}: {ex.Message}", ex);
            }
        }



        public async Task<bool> DeleteUserAsync(int id)
        {
            var deleteUserQuery = @"
                                    DELETE FROM usuarios
                                    WHERE Id = @Id";
            try
            {
                using var connection = _dapperContext.CreateConnection();

                // Ejecutar la eliminación
                var rowsAffected = await connection.ExecuteAsync(deleteUserQuery, new { Id = id });

                // Retorna true si se eliminó al menos una fila, false en caso contrario
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al eliminar el usuario con Id {id}: {ex.Message}", ex);
            }
        }
    }
}
