# Gesti�n de Variables

Prueba tecnica para neosoft 

## Caracter�sticas

- **Crear**: Permite agregar nuevas variables con atributos como nombre, valor y tipo.
- **Leer**: Recupera variables individuales o listas de variables.
- **Actualizar**: Modifica los atributos de una variable existente.
- **Eliminar**: Elimina variables por su ID.

## Tecnolog�as utilizadas

- **Lenguaje**: C#
- **Framework**: .NET
- **ORM**: Dapper
- **Base de datos**: MySQL
- **IDE**: Visual Studio

## Estructura del proyecto

- **DTOs**: Contienen los modelos de datos para transferir informaci�n entre capas.
- **Repositorios**: Implementan la l�gica de acceso a datos utilizando Dapper.
- **Servicios**: Contienen la l�gica de negocio.
- **Controladores**: Exponen los endpoints de la API.

## Endpoints principales

### Variables
- **POST** `/variables`: Crear una nueva variable.
- **GET** `/variables/{id}`: Obtener una variable por su ID.
- **PUT** `/variables/{id}`: Actualizar una variable existente.
- **DELETE** `/variables/{id}`: Eliminar una variable por su ID.

### Usuarios
- **POST** `/usuarios`: Crear un nuevo usuario.
- **GET** `/usuarios`: Obtener todos los usuarios.
- **GET** `/usuarios/{id}`: Obtener un usuario por su ID.
- **PUT** `/usuarios/{id}`: Actualizar un usuario existente.
- **DELETE** `/usuarios/{id}`: Eliminar un usuario por su ID.

### Rol
- **POST** `/rol`: Crear un nuevo rol.
- **GET** `/rol`: Obtener todos los roles.
- **GET** `/rol/{id}`: Obtener un rol por su ID.
- **PUT** `/rol/{id}`: Actualizar un rol existente.
- **DELETE** `/rol/{id}`: Eliminar un rol por su ID.

## Configuraci�n del proyecto

1. Clona el repositorio:
   
  ``` git clone <URL_DEL_REPOSITORIO>  ```

2. Configura la cadena de conexi�n a la base de datos en el archivo `appsettings.json`:

   ```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Server=localhost;Database=nombre_base_datos;User Id=usuario;Password=contrase�a;"
  }
}

```
3. Restaura los paquetes NuGet necesarios:
   ```bash
   dotnet restore
   ```
