# User Management API

A RESTful ASP.NET Core Web API for managing users. This project demonstrates a clean backend architecture using Controllers, Services, DTOs, Entity Framework Core, Middleware, and Dependency Injection.

## Features

- CRUD operations for users
- Entity Framework Core integration
- DTO pattern for request and response models
- Dependency Injection
- Request/Response logging middleware
- Global exception handling middleware
- Token-based authentication middleware
- SQL Server or SQLite support
- Swagger/OpenAPI documentation
- Validation using Data Annotations
- Async API operations

---

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / SQLite
- Swagger
- Dependency Injection
- Middleware Pipeline
- C#

---

## Project Structure

```text
UserManagementAPI
│
├── Controllers
│   └── UsersController.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── DTOs
│   ├── CreateUserDto.cs
│   ├── UpdateUserDto.cs
│   └── UserDto.cs
│
├── Middleware
│   ├── AuthenticationMiddleware.cs
│   ├── GlobalExceptionMiddleware.cs
│   └── RequestResponseLoggingMiddleware.cs
│
├── Models
│   └── User.cs
│
├── Services
│   ├── IUserService.cs
│   └── UserService.cs
│
├── Program.cs
│
├── appsettings.json
│
└── README.md
```

---

## API Endpoints

### Get All Users

```http
GET /api/users
```

Response:

```json
[
  {
    "id": 1,
    "firstName": "John",
    "lastName": "Doe",
    "email": "john@example.com",
    "createdAtUtc": "2024-01-01T00:00:00Z"
  }
]
```

---

### Get User By Id

```http
GET /api/users/{id}
```

Example:

```http
GET /api/users/1
```

---

### Create User

```http
POST /api/users
```

Request:

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@example.com"
}
```

Response:

```http
201 Created
```

---

### Update User

```http
PUT /api/users/{id}
```

Request:

```json
{
  "firstName": "John",
  "lastName": "Updated",
  "email": "john@example.com"
}
```

Response:

```http
204 No Content
```

---

### Delete User

```http
DELETE /api/users/{id}
```

Response:

```http
204 No Content
```

---

## Authentication

The API uses a custom authentication middleware that validates bearer tokens.

Example request:

```http
GET /api/users
Authorization: Bearer my-super-secret-token
```

If the token is invalid or missing:

```http
401 Unauthorized
```

Response:

```json
{
  "error": "Unauthorized."
}
```

---

## Global Exception Handling

Unhandled exceptions are intercepted by the global exception middleware.

Example response:

```http
500 Internal Server Error
```

```json
{
  "error": "Internal server error."
}
```

This prevents sensitive application details from being exposed to clients.

---

## Request Logging

Every request is logged with:

- HTTP Method
- Request Path
- Response Status Code
- Execution Time

Example:

```text
Method: GET | Path: /api/users | StatusCode: 200 | Duration: 25ms
```

---

## Database Configuration

### SQL Server

Example connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=UserDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### SQLite

Example connection string:

```csharp
options.UseSqlite("Data Source=users.db");
```

---

## Entity Framework Migrations

Create a migration:

```bash
dotnet ef migrations add InitialCreate
```

Apply migrations:

```bash
dotnet ef database update
```

---

## Running the Application

Restore dependencies:

```bash
dotnet restore
```

Build:

```bash
dotnet build
```

Run:

```bash
dotnet run
```

Swagger UI will be available at:

```text
https://localhost:<port>/swagger
```

---

## HTTP Status Codes

| Status Code | Description |
|-------------|-------------|
| 200 | OK |
| 201 | Created |
| 204 | No Content |
| 400 | Bad Request |
| 401 | Unauthorized |
| 404 | Not Found |
| 409 | Conflict |
| 500 | Internal Server Error |

---

## Design Patterns and Practices

This project follows several backend development best practices:

- Separation of Concerns
- Dependency Injection
- DTO Pattern
- Service Layer Pattern
- Middleware Pipeline
- Asynchronous Programming
- RESTful API Design
- Error Handling Centralization

---

