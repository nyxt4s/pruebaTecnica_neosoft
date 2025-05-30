using Dapper;
using MantenedorApi.Data;
using MantenedorApi.DTOs;
using MantenedorApi.Models;

namespace MantenedorApi.Repository
{
    public class VariableRepository : IVariableRepository
    {
        private readonly DapperContext _dapperContext;
        public VariableRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<Variable> CreateVariableAsync(VariableDTO variable)
        {
            var query = @"
                            INSERT INTO variables (Nombre, Valor)
                            VALUES (@Nombre, @Valor);
                             SELECT LAST_INSERT_ID();";

            try
            {
                using var connection = _dapperContext.CreateConnection();

                // Ejecutar la consulta y obtener el ID generado
                var newVariableId = await connection.QuerySingleAsync<int>(query, new { variable.Nombre, variable.Valor });

                if (newVariableId == 0)
                {
                    throw new Exception("No se pudo crear el usuario. Verifica que los datos sean válidos.");
                }
                // Retorna la  variable creado con el ID Variable
                return new Variable
                {
                    Id = newVariableId,
                    Nombre = variable.Nombre,
                    Valor = variable.Valor,
                    Tipo = variable.Tipo
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al crear la variable: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteVariableAsync(int id)
        {
            var deleteVariableQuery = @"
                                        DELETE FROM variables
                                        WHERE Id = @Id";

            try
            {
                using var connection = _dapperContext.CreateConnection();

                // Ejecutar la eliminación
                var rowsAffected = await connection.ExecuteAsync(deleteVariableQuery, new { Id = id });

                // Retorna true si se eliminó al menos una fila, false en caso contrario
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al eliminar la variable con Id {id}: {ex.Message}", ex);
            }
        }



        public async Task<IEnumerable<Variable>> GetAllVariablesAsync()
        {
             var query = @"
                SELECT Id, Nombre, Valor
                FROM variables";

            try
            {
                using var connection = _dapperContext.CreateConnection();

                var variables = await connection.QueryAsync<Variable>(query);

                return variables;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al obtener las variables: {ex.Message}", ex);
            }
        }

        public async Task<Variable?> GetVariableByIdAsync(int id)
        {
            var query = @"
                        SELECT Id, Nombre, Valor
                        FROM variables
                        WHERE Id = @Id";

            try
            {
                using var connection = _dapperContext.CreateConnection();

                // Ejecutar la consulta y obtener la variable por ID
                var variable = await connection.QuerySingleOrDefaultAsync<Variable>(query, new { Id = id });

                return variable; // Retorna la variable o null si no se encuentra
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al obtener la variable con Id {id}: {ex.Message}", ex);
            }
        }

        public async Task<Variable?> UpdateVariableAsync(int id, VariableDTO variable)
        {
            var updateVariableQuery = @"
                                        UPDATE variables
                                        SET Nombre = @Nombre, Valor = @Valor, Tipo = @Tipo
                                        WHERE Id = @Id";

                                            var getVariableQuery = @"
                                        SELECT 
                                            Id AS VariableId,
                                            Nombre AS VariableName,
                                            Valor AS VariableValue,
                                            Tipo AS VariableType
                                        FROM variables
                                        WHERE Id = @Id";

            try
            {
                using var connection = _dapperContext.CreateConnection();

                // Ejecutar la actualización
                var rowsAffected = await connection.ExecuteAsync(updateVariableQuery, new
                {
                    Nombre = variable.Nombre,
                    Valor = variable.Valor,
                    Tipo = variable.Tipo,
                    Id = id
                });

                if (rowsAffected == 0)
                {
                    return null; // Retorna null si no se actualizó ninguna fila
                }

                // Obtener la variable actualizada
                var result = await connection.QuerySingleOrDefaultAsync(getVariableQuery, new { Id = id });

                if (result == null)
                {
                    return null; // Retorna null si no se encuentra la variable
                }

                // Mapea los datos al modelo Variable
                var updatedVariable = new Variable
                {
                    Id = result.VariableId,
                    Nombre = result.VariableName,
                    Valor = result.VariableValue,
                    Tipo = result.VariableType
                };

                return updatedVariable;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al actualizar la variable con Id {id}: {ex.Message}", ex);
            }
        }
    }
}
