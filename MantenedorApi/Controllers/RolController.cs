using Microsoft.AspNetCore.Mvc;
using MantenedorApi.Models;
using MantenedorApi.Services.Interfaces;
using System;
using System.Threading.Tasks;
using MantenedorApi.DTOs;

namespace MantenedorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        // GET: api/rol
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roles = await _rolService.GetAllRolsAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // GET: api/rol/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var rol = await _rolService.GetRolByIdAsync(id);
                if (rol == null)
                {
                    return NotFound(new { message = $"Rol con Id {id} no encontrado." });
                }
                return Ok(rol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // POST: api/rol
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRolDTO rol)
        {
            try
            {
                var createdRol = await _rolService.CreateRolAsync(rol);
                return CreatedAtAction(nameof(GetById), new { id = createdRol.Id }, createdRol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // PUT: api/rol/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRolAsync(int id, UpdateRolDTO rol)
        {
            try
            {
                var updatedRol = await _rolService.UpdateRolAsync(id, rol);

            if (updatedRol == null)
            {
                return NotFound(new { message = $"No se encontró el rol con Id {id} o no se pudo actualizar." });
            }

            return Ok(updatedRol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // DELETE: api/rol/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _rolService.DeleteRolAsync(id);
                if (result == false)
                {
                    return NotFound(new { success = false, message = $"No se encontró el rol con Id {id} o no se pudo eliminar." });
                }
                else
                {
                    return Ok(new { success = true, message = "Rol eliminado exitosamente." });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
