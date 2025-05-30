using MantenedorApi.DTOs;
using MantenedorApi.Models;
using MantenedorApi.Models.Response;
using MantenedorApi.Repository.Interfaces;
using MantenedorApi.Services.Interfaces;
using MantenedorApi.Utils.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MantenedorApi.Services
{
    public class VariableService : IVariableService
    {
        private readonly IVariableRepository _variableRepository;


        public VariableService(IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        /// <summary>
        /// Obtiene todas las variables.
        /// </summary>
        /// <returns>Una lista con todas las variables.</returns>
        public async Task<IEnumerable<Variable>> GetAllVariablesAsync()
        {
            return await _variableRepository.GetAllVariablesAsync();
        }

        /// <summary>
        /// Obtiene una variable por su ID.
        /// </summary>
        /// <param name="id">ID de la variable a buscar.</param>
        /// <returns>La variable encontrada o null si no existe.</returns>
        public async Task<ResponseMessage<Variable>> GetVariableByIdAsync(int id)
        {
            try
            {
                // Obtener la variable por ID
                var variable = await _variableRepository.GetVariableByIdAsync(id);

                if (variable == null)
                {
                    return new ResponseMessage<Variable>
                    {
                        Success = false,
                        Message = $"No se encontró la variable con Id {id}.",
                        Data = null
                    };
                }

                return new ResponseMessage<Variable>
                {
                    Success = true,
                    Message = "Variable encontrada exitosamente.",
                    Data = variable
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessage<Variable>
                {
                    Success = false,
                    Message = $"Error inesperado al buscar la variable con Id {id}: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Crea una nueva variable.
        /// </summary>
        /// <param name="variable">Objeto Variable con los datos a crear.</param>
        /// <returns>La variable creada con su ID.</returns>
        public async Task<ResponseMessage<Variable>> CreateVariableAsync(VariableDTO variable)
        {
            try
            {
                var validateData = new ValidateData();
                // Validar que la variable no sea nula
                if (variable == null)
                {
                    return new ResponseMessage<Variable>
                    {
                        Success = false,
                        Message = "La variable proporcionada es inválida.",
                        Data = null
                    };
                }

                // Validar que el tipo coincida con el valor
                if (!validateData.IsValueTypeValid(variable.Tipo, variable.Valor))
                {
                    return new ResponseMessage<Variable>
                    {
                        Success = false,
                        Message = $"El valor '{variable.Valor}' no coincide con el tipo '{variable.Tipo}'.",
                        Data = null
                    };
                }

                // Crear la variable
                var createdVariable = await _variableRepository.CreateVariableAsync(variable);

                return new ResponseMessage<Variable>
                {
                    Success = true,
                    Message = "Variable creada exitosamente.",
                    Data = createdVariable
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessage<Variable>
                {
                    Success = false,
                    Message = $"Error inesperado al crear la variable: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Actualiza una variable existente.
        /// </summary>
        /// <param name="id">ID de la variable a actualizar.</param>
        /// <param name="variable">Objeto Variable con los nuevos datos.</param>
        /// <returns>La variable actualizada.</returns>
        public async Task<ResponseMessage<Variable>> UpdateVariableAsync(int id, VariableDTO variable)
        {
            try
            {
                var validateData = new ValidateData();
                // Validar que la variable no sea nula
                if (variable == null)
                {
                    return new ResponseMessage<Variable>
                    {
                        Success = false,
                        Message = "La variable proporcionada es inválida.",
                        Data = null
                    };
                }

                // Validar que el tipo coincida con el valor
                if (!validateData.IsValueTypeValid(variable.Tipo, variable.Valor))
                {
                    return new ResponseMessage<Variable>
                    {
                        Success = false,
                        Message = $"El valor '{variable.Valor}' no coincide con el tipo '{variable.Tipo}'.",
                        Data = null
                    };
                }

                // actualizar la variable
                var createdVariable = await _variableRepository.UpdateVariableAsync(id, variable);

                if (createdVariable == null)
                {
                    return new ResponseMessage<Variable>
                    {
                        Success = false,
                        Message = "La variable proporcionada no se encuentra en la base de datos.",
                        Data = null
                    };
                }

                return new ResponseMessage<Variable>
                {
                    Success = true,
                    Message = "Variable creada exitosamente.",
                    Data = createdVariable
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessage<Variable>
                {
                    Success = false,
                    Message = $"Error inesperado al crear la variable: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Elimina una variable por su ID.
        /// </summary>
        /// <param name="id">ID de la variable a eliminar.</param>
        /// <returns>Mensaje de confirmación o resultado de la operación.</returns>
        public async Task<bool> DeleteVariableAsync(int id)
        {
            return await _variableRepository.DeleteVariableAsync(id);
        }
    }
}
