<!-- TOC -->
* [.NET 9 PostgreSQL CRUD Example (Users, Orders & Addresses)](#net-9-postgresql-crud-example-users-orders--addresses)
  * [How to run](#how-to-run)
  * [Endpoints](#endpoints)
    * [Users](#users)
    * [Orders](#orders)
    * [Addresses](#addresses)
<!-- TOC -->

# .NET 9 PostgreSQL CRUD Example (Users, Orders & Addresses)

This is a .NET rewrite of the original Python FastAPI CRUD example (users, orders & addresses). It uses **ASP.NET Core 8**, **Entity Framework Core**, and **PostgreSQL**.

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

### Users

- `GET /users` – list all users
- `GET /users/{id}` – get a single user
- `POST /users` – create user (body: `{ "name": "Alice", "email": "alice@example.com" }`)
- `PUT /users/{id}` – update user
- `DELETE /users/{id}` – delete user

### Orders

- `GET /orders` – list all orders
- `GET /orders/{id}` – get a single order
- `POST /orders` – create order (body: `{ "item": "Book", "quantity": 1 }`)
- `PUT /orders/{id}` – update order
- `DELETE /orders/{id}` – delete order

### Addresses

- `GET /addresses` – list all addresses
- `GET /addresses/{id}` – get a single address
- `POST /addresses` – create address (body: `{ "street": "123 Main St", "city": "Metropolis" }`)
- `PUT /addresses/{id}` – update address
- `DELETE /addresses/{id}` – delete address

> Note: This version keeps Users, Orders and Addresses independent (no foreign keys)
