using MantenedorApi.DTOs;
using MantenedorApi.Models;

public interface IVariableRepository 
{
    Task<IEnumerable<Variable>> GetAllVariablesAsync();
    Task<Variable> GetVariableByIdAsync(int id);
    Task<Variable> CreateVariableAsync(VariableDTO variable);
    Task<Variable> UpdateVariableAsync(int id, VariableDTO variable);
    Task<bool> DeleteVariableAsync(int id);
}