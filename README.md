# Instrucciones para ejecutar el proyecto

## Requisitos previos

- Tener instalado **MariaDB**
- Tener instalado **.NET SDK 8+**
- Tener instalado **Node.js 22.16 y **npm**

---

## Backend (`MantenedorApi`)

1. **Ejecutar el script de base de datos en MariaDB**  
   [scripts_test.sql](https://github.com/nyxt4s/pruebaTecnica_neosoft/blob/main/scripts_test.sql)

2. **Abrir el proyecto `MantenedorApi`**

3. **Configurar la cadena de conexión en `appsettings.json`:**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=nombre_base_datos;User Id=usuario;Password=contraseña;"
     }
   }
   ```

4. **Restaurar los paquetes NuGet:**
   ```bash
   dotnet restore
   ```

5. **Levantar el proyecto:**
   ```bash
   dotnet run
   ```

6. **Probar los endpoints**  
   Puedes usar Postman, Swagger o tu navegador para probar los endpoints expuestos por la API.

---

## Frontend (`mantenedorWeb`)

1. **Abrir el proyecto `mantenedorWeb`**

2. **Instalar las dependencias:**
   ```bash
   npm install
   ```

3. **Configurar la URL de la API en Angular**  
   Modifica la siguiente línea en el archivo:

   ```
   mantenedorWeb/src/app/services/user.service.ts
   ```

   Cambia la línea:
   ```typescript
   private apiUrl = 'https://localhost:7032/api/Users';
   ```
   por la URL y puerto donde se está ejecutando tu API.

4. **Levantar la aplicación Angular:**
   ```bash
   npm start
   ```

---

¡Listo! Ahora puedes acceder a la aplicación web y consumir los endpoints de la API.