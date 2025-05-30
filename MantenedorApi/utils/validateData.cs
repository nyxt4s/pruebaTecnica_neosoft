

namespace MantenedorApi.Utils.Validation
{
    public class ValidateData
    {

        /// <summary>
        /// Valida que el valor coincida con el tipo especificado.
        /// </summary>
        /// <param name="tipo">Tipo de la variable (por ejemplo, "string", "int").</param>
        /// <param name="valor">Valor de la variable.</param>
        /// <returns>True si el valor coincide con el tipo, false en caso contrario.</returns>
        public bool IsValueTypeValid(string tipo, object valor)
        {
            switch (tipo.ToLower())
            {
                case "texto":
                    return valor is string;
                case "numerico":
                    return int.TryParse(valor?.ToString(), out _);
                case "booleano":
                    return bool.TryParse(valor?.ToString(), out _);
                default:
                    return false; // Tipo no soportado
            }
        }


        /// <summary>
        /// Valida si un email tiene un formato correcto.
        /// </summary>
        /// <param name="email">Email a validar.</param>
        /// <returns>True si el email es válido, false en caso contrario.</returns>
        public bool IsValidEmail(string email)
        {
            var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailRegex);
        }
    }

}