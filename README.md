# UserManagementAPI – ASP.NET Core Web API

UserManagementAPI is a RESTful API built with ASP.NET Core that provides user registration, authentication, role management, and basic CRUD operations. This API can serve as a backend for admin panels, web applications, or mobile apps requiring secure user handling.

## 🔍 Features

- 🔐 **User Registration & Login**
- 📄 **JWT Authentication**
- 🧑‍💼 **Role-Based Authorization (Admin/User/Other)**
- 📝 **CRUD operations on Users**
- 💾 **Entity Framework Core Integration**
- 🔄 **Refresh Token Support** (optional)
- 🧪 **Swagger API Documentation**

---

## 🧰 Tech Stack

| Technology            | Description                    |
|------------------------|-------------------------------|
| ASP.NET Core Web API   | Backend framework              |
| Entity Framework Core  | ORM for DB access              |
| SQL Server             | Relational Database            |
| JWT Authentication     | Secure login & authorization   |
| Swagger / Swashbuckle  | API documentation              |
| AutoMapper             | DTO and entity mapping         |
| Git & GitHub           | Version control                |

---

## 📁 Endpoints Overview

| Method | Endpoint              | Description                |
|--------|-----------------------|----------------------------|
| POST   | `/api/auth/register`  | Register new user          |
| POST   | `/api/auth/login`     | Authenticate user          |
| GET    | `/api/users`          | Get list of users (Admin)  |
| GET    | `/api/users/{id}`     | Get user by ID             |
| PUT    | `/api/users/{id}`     | Update user                |
| DELETE | `/api/users/{id}`     | Delete user                |
| POST   | `/api/roles`          | Create a new role          |
| POST   | `/api/users/{id}/roles` | Assign role to user     |

---

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2022+
- .NET SDK 6 or later
- SQL Server 2019 or later
- Postman or Swagger UI for testing

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/asad-mehsud/UserManagementAPI.git
