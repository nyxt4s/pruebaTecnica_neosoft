namespace MantenedorApi.Models
{
    // Clase que representa los parametros necesario para crear un Rol
    public class CreateRolDTO
    {
        // Nombre del rol (por ejemplo: "Administrador", "Usuario", etc.)
        public string Nombre { get; set; } = string.Empty;
    }
}
