1# Creacion del proyecto
dotnet new webapi -n MantenedorApi

2# Instalacion de paquetes nuggets para Dapper - https://www.nuget.org/packages/dapper/
dotnet add package Dapper

3# Instalacion de paquestes nuggets para Mysql - https://www.nuget.org/packages/MySqlConnector
dotnet add package MySqlConnector

4# Instalacion de paquetes nuggets para Swashbuckle (permite la auto generacion de endpoint y mostrarlo en swagger)- https://www.nuget.org/packages/swashbuckle.aspnetcore
dotnet add package Swashbuckle.AspNetCore

5# Creamos el connection string con la base de datos
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=mantenedordb;user=root;password=1234;"
  },

6# Creamos la carpeta Data que sera encargada de almacenar las conecciones
mkdir Data

7# Generamos el contexto de Dapper

8# Procedemos a crear la carpeta Models y sus respectivas clases representando las tablas, tambien comentamos la variables como buena practicas, dado que esto
	permitira que otros desarrollador ajenos al proyecto de integren mas facil

9# Agregamos la configuracion en Programcs para la busqueda de controladore

10# Luego comenzamos a crear la carpeta Controller, que sera encargada de almacenar todos los controladores y agregamos controller de prueba para verificar si se
configuro correctamente

11# luego de esos creamos la carpeta Services que sera la encargada de realizar la logica en los endpoints, con sus respectivas funciones

12# luego regresamos a los controladores y generamos la injeccion de dependencias para todas las funciones creadas anteriormente

13# procedemos a agregar los scoped y probar 
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IVariableService, VariableService>();

14## procedemos a crear los repository, primero la carpeta en donde sera almacenado y dentro de esta la carpeta Interfaces

15# luego de esto comenzamos a injectar el repository en los services 



