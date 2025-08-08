# .NET 8 PostgreSQL CRUD Example (Users & Orders)

This is a .NET rewrite of the original Python FastAPI CRUD example (users & orders). It uses **ASP.NET Core 8**, **Entity Framework Core**, and **PostgreSQL**.

## How to run

1. **Install .NET 9 SDK** and have **PostgreSQL** running locally.
2. Update the connection string in `BasicCrud.Api/appsettings.json` if needed.
3. Restore packages and run migrations:

```bash
cd BasicCrud.Api
dotnet restore
dotnet tool install --global dotnet-ef || true
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

- Swagger UI: http://localhost:5180/swagger (or the https port shown in console)

## Endpoints

- `GET /users` – list all users
- `GET /users/{id}` – get a single user
- `POST /users` – create user (body: `{ "name": "Alice", "email": "alice@example.com" }`)
- `PUT /users/{id}` – update user
- `DELETE /users/{id}` – delete user

- `GET /orders` – list all orders
- `GET /orders/{id}` – get a single order
- `POST /orders` – create order (body: `{ "item": "Book", "quantity": 1 }`)
- `PUT /orders/{id}` – update order
- `DELETE /orders/{id}` – delete order

> Note: This version keeps Users and Orders independent (no foreign keys), matching the original example's request bodies.
