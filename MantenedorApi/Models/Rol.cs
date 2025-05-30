namespace MantenedorApi.Models
{
    // Clase que representa un rol de usuario 
    public class Rol
    {
        // Identificador único del rol
        public int Id { get; set; }

        // Nombre del rol (por ejemplo: "Administrador", "Usuario", etc.)
        public string Nombre { get; set; } = string.Empty;
    }
}
