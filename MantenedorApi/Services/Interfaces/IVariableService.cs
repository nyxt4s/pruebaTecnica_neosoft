using MantenedorApi.DTOs;
using MantenedorApi.Models;
using MantenedorApi.Models.Response;
using System.Threading.Tasks;


namespace MantenedorApi.Repository.Interfaces
{
    public interface IVariableService
    {
        Task<IEnumerable<Variable>> GetAllVariablesAsync();

        Task<ResponseMessage<Variable>> GetVariableByIdAsync(int id);

        Task<ResponseMessage<Variable>> CreateVariableAsync(VariableDTO variable);

        Task<ResponseMessage<Variable>> UpdateVariableAsync(int id, VariableDTO variable);

        Task<bool> DeleteVariableAsync(int id);
    }
}
