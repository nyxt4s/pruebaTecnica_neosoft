# Gestión de Variables

Prueba tecnica para neosoft 

## Características

- **Crear**: Permite agregar nuevas variables con atributos como nombre, valor y tipo.
- **Leer**: Recupera variables individuales o listas de variables.
- **Actualizar**: Modifica los atributos de una variable existente.
- **Eliminar**: Elimina variables por su ID.

## Tecnologías utilizadas

- **Lenguaje**: C#
- **Framework**: .NET
- **ORM**: Dapper
- **Base de datos**: MySQL
- **IDE**: Visual Studio

## Estructura del proyecto

- **DTOs**: Contienen los modelos de datos para transferir información entre capas.
- **Repositorios**: Implementan la lógica de acceso a datos utilizando Dapper.
- **Servicios**: Contienen la lógica de negocio.
- **Controladores**: Exponen los endpoints de la API.

## Endpoints principales

### Variables
- **POST** `/variables`: Crear una nueva variable.
- **GET** `/variables/{id}`: Obtener una variable por su ID.
- **PUT** `/variables/{id}`: Actualizar una variable existente.
- **DELETE** `/variables/{id}`: Eliminar una variable por su ID.

## Configuración del proyecto

1. Clona el repositorio:
   
  ``` git clone <URL_DEL_REPOSITORIO>  ```

2. Configura la cadena de conexión a la base de datos en el archivo `appsettings.json`:

   ```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Server=localhost;Database=nombre_base_datos;User Id=usuario;Password=contraseña;"
  }
}

```
3. Restaura los paquetes NuGet necesarios:
   ```bash
   dotnet restore
   ```
