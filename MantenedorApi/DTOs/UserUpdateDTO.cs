namespace MantenedorApi.Models
{
    // Clase que representa un usuario en el sistema
    public class UserUpdateDTO
    {
        // Nombre completo del usuario
        public string Nombre { get; set; } = string.Empty;

        // Correo electrónico del usuario
        public string Email { get; set; } = string.Empty;

        // Clave foránea que referencia el rol asignado al usuario
        public int rol { get; set; }

        // Propiedad opcional para acceso directo al objeto Role relacionado
        // public Role? Rol { get; set; }
    }
}
