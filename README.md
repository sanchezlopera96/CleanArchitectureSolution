# Clean Architecture Solution

Este proyecto es una **API REST** desarrollada en **.NET 6 (ASP.NET Core Web API)** que implementa una arquitectura basada en **Clean Architecture**, permitiendo la gestión de **clientes** y **órdenes**, con persistencia en **SQL Server**.

El objetivo del proyecto es demostrar buenas prácticas de desarrollo de software, separación de responsabilidades, uso de Entity Framework Core y pruebas unitarias.

---

## 🧱 Arquitectura

La solución está organizada siguiendo los principios de **Clean Architecture**, separando claramente las responsabilidades:

### 🟦 Domain
Contiene la lógica central del negocio.
- Entidades:
  - `Customer`
  - `Order`
- Interfaces:
  - `ICustomerRepository`

Esta capa **no depende de ninguna otra**.

---

### 🟩 Application
Contiene los casos de uso del sistema.
- Servicios de dominio:
  - `OrderService`
- Lógica para crear y cancelar órdenes
- Pruebas unitarias con **xUnit** y **Moq**

Depende únicamente de **Domain**.

---

### 🟨 Infrastructure
Encargada del acceso a datos.
- `AppDbContext` (Entity Framework Core)
- Implementación de repositorios
- Configuración de SQL Server

Depende de **Domain**.

---

### 🟥 Presentation
Capa de entrada al sistema.
- Controladores REST (`CustomerController`)
- Configuración de dependencias
- Swagger para pruebas de la API

Depende de todas las capas anteriores.

---

## ⚙️ Tecnologías utilizadas

- .NET 6
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server Express
- Swagger (OpenAPI)
- xUnit
- Moq

---

## 🗄️ Base de Datos

La aplicación utiliza **SQL Server Express**.

### Script SQL

El script para crear la base de datos y las tablas se encuentra en **/scripts/database.sql**


Este script crea:
- Base de datos `OrderDb`
- Tabla `Customers`
- Tabla `Orders`
- Relación entre clientes y órdenes

---

### Cadena de conexión

Archivo en Presentation/appsettings.json que contiene:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=OrderDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}


▶️ Ejecución del proyecto

Clonar el repositorio

Ejecutar el script database.sql en SQL Server Management Studio

Abrir la solución en Visual Studio

Ejecutar el proyecto Presentation

Acceder a Swagger desde el navegador:

https://localhost:{puerto}/swagger


🧪 Pruebas unitarias

El proyecto incluye pruebas unitarias para el servicio OrderService.

Para ejecutar las pruebas:

dotnet test

Se validan:

- Creación de órdenes
- Cancelación de órdenes

Swagger

<img width="1584" height="656" alt="image" src="https://github.com/user-attachments/assets/0bfa1849-ed74-4c0a-9291-f9470f104801" />

Sql Server

<img width="922" height="342" alt="image" src="https://github.com/user-attachments/assets/dc67e2bf-028b-4e65-ba4d-5dead5c4c97f" />

Test

<img width="908" height="393" alt="image" src="https://github.com/user-attachments/assets/0c0857e0-be07-4577-84bc-cd8ed69e615e" />


