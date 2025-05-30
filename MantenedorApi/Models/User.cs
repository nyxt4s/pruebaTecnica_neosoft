namespace MantenedorApi.Models
{
    // Clase que representa un usuario en el sistema
    public class User
    {
        // Identificador único del usuario
        public int Id { get; set; }

        // Nombre completo del usuario
        public string Nombre { get; set; } = string.Empty;

        // Correo electrónico del usuario
        public string Email { get; set; } = string.Empty;

        // Clave foránea que referencia el rol asignado al usuario
        public Rol rol { get; set; } = new Rol();

        // Propiedad opcional para acceso directo al objeto Role relacionado
        // public Role? Rol { get; set; }
    }
}
