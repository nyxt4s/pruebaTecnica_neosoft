namespace MantenedorApi.DTOs
{
    public class VariableDTO
    {
        
        // Nombre descriptivo de la variable
        public string Nombre { get; set; } = string.Empty;

        // Valor asignado a la variable (como texto)
        public string Valor { get; set; } = string.Empty;

        // Tipo de dato de la variable (por ejemplo: "texto", "número", "booleano", etc.)
        public string Tipo { get; set; } = "texto";
    }
}
