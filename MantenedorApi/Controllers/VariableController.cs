using Microsoft.AspNetCore.Mvc;
using MantenedorApi.Models;
using MantenedorApi.Repository.Interfaces;
using MantenedorApi.DTOs;

namespace MantenedorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VariableController : ControllerBase
    {
        private readonly IVariableService _variableService;

        public VariableController(IVariableService variableService)
        {
            _variableService = variableService;
        }

        // GET: api/variable
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var variables = await _variableService.GetAllVariablesAsync();
                return Ok(variables);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // GET: api/variable/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var variable = await _variableService.GetVariableByIdAsync(id);
                return Ok(variable);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/variable
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VariableDTO variable)
        {
            try
            {
                var response = await _variableService.CreateVariableAsync(variable);

                if (!response.Success)
                {
                    return BadRequest(new { message = response.Message });
                }

                return Ok(new
                {
                    message = response.Message,
                    variable = response.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error interno: {ex.Message}" });
            }
        }

        // PUT: api/variable/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VariableDTO variable)
        {
            try
            {
                var response = await _variableService.UpdateVariableAsync(id, variable);

                if (!response.Success)
                {
                    return BadRequest(new { message = response.Message });
                }

                return Ok(new
                {
                    message = response.Message,
                    variable = response.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error interno: {ex.Message}" });
            }
        }
        

        // DELETE: api/variable/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedVariable = await _variableService.DeleteVariableAsync(id);
                return Ok(deletedVariable);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
