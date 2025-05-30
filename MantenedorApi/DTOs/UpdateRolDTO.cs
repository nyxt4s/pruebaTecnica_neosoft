namespace MantenedorApi.DTOs
{
    // Clase que representa los parametros necesario para actualizar un Rol
    public class UpdateRolDTO
    {
        // Nombre del rol (por ejemplo: "Administrador", "Usuario", etc.)
        public string Nombre { get; set; } = string.Empty;
    }
}
