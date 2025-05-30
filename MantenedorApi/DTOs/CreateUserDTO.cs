using MantenedorApi.Models;

namespace MantenedorApi.DTOs
{
    // Clase que se utiliza para crear un usuario en el sistema
    public class CreateUserDTO
    {
        
     
            // Nombre completo del usuario
            public string Nombre { get; set; } = string.Empty;

            // Correo electrónico del usuario
            public string Email { get; set; } = string.Empty;

            // Clave foránea que referencia el rol asignado al usuario
            public int rolId { get; set; }
        
    }
}
