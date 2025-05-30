using MantenedorApi.Models;
using MantenedorApi.Repository.Interfaces;
using MantenedorApi.Data;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MantenedorApi.DTOs;

namespace MantenedorApi.Repository
{
    public class RolRepository : IRolRepository
    {
        private readonly DapperContext _dapperContext;

        public RolRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            var query = "SELECT * FROM Roles";

            try
            {
                using var connection = _dapperContext.CreateConnection();
                return await connection.QueryAsync<Rol>(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener los roles.", ex);
            }
        }
        public async Task<Rol?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Roles WHERE Id = @Id";

            try
            {
                using var connection = _dapperContext.CreateConnection();
                var rol = await connection.QuerySingleOrDefaultAsync<Rol>(query, new { Id = id });
                return rol; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener el rol.", ex);
            }
        }



        public async Task<Rol> CreateAsync(CreateRolDTO rol)
        {
            var sql = @"INSERT INTO Roles (Nombre)
                VALUES (@Nombre);
                SELECT LAST_INSERT_ID();";

            try
            {
                using (var connection = _dapperContext.CreateConnection())
                {
                    var newRolId = await connection.QuerySingleOrDefaultAsync<int>(sql, new { rol.Nombre });

                    if (newRolId == 0)
                    {
                        throw new Exception("No se pudo crear el rol. Verifica que los datos sean válidos.");
                    }

                    return new Rol
                    {
                        Id = newRolId,
                        Nombre = rol.Nombre
                    };
                }
            }
            catch (Exception ex)
            {
                // Captura otros errores inesperados
                throw new Exception($"Error inesperado al crear el rol: {ex.Message}", ex);
            }
        }


        public async Task<Rol> UpdateAsync(int id, UpdateRolDTO rol)
        {
            var updateSql = @"
                UPDATE Roles
                SET Nombre = @Nombre
                WHERE Id = @Id
            ";

            var selectSql = "SELECT * FROM Roles WHERE Id = @Id";

            try
            {
                using var connection = _dapperContext.CreateConnection();

                var affectedRows = await connection.ExecuteAsync(updateSql, new { rol.Nombre, Id = id });

                if (affectedRows == 0)
                {
                    return null;
                }

                var updatedRol = await connection.QuerySingleAsync<Rol>(selectSql, new { Id = id });
                return updatedRol;
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al actualizar el rol.", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteSql = "DELETE FROM Roles WHERE Id = @Id";

            try
            {
                using var connection = _dapperContext.CreateConnection();
                var affectedRows = await connection.ExecuteAsync(deleteSql, new { Id = id });
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al eliminar el rol.", ex);
            }
        }
    }
}
