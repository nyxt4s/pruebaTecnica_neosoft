/* • Usuarios
o Id (int, autoincremental)
o Nombre (string)
o Email (string)
o RolId (foreign key hacia tabla Roles): debe seleccionarse desde una lista
desplegable (dropdown) que cargue dinámicamente los valores disponibles desde
la API.
• Roles
o Id (int, autoincremental)
o Nombre (string)
• Variables
o Id (int, autoincremental)
o Nombre (string)
o Valor (string)
o Tipo (enum o string: “texto”, “numérico”, “booleano”)
*/

CREATE DATABASE IF NOT EXISTS MantenedorDb 
USE MantenedorDb;

CREATE TABLE Roles (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    RolId INT NOT NULL,
    FOREIGN KEY (RolId) REFERENCES Roles(Id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
);

CREATE TABLE Variables (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Valor VARCHAR(255) NOT NULL,
    Tipo ENUM('texto', 'numérico', 'booleano') NOT NULL
);

