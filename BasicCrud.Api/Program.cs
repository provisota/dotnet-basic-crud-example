using BasicCrud.Api.Data;
using Microsoft.EntityFrameworkCore;
using BasicCrud.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register repositories and services
builder.Services.AddApplicationServices();

// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS: allow all in Development to avoid Swagger "Failed to fetch" issues
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", p => p
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// Configure EF Core with PostgreSQL.
// Connection string comes from appsettings.json (ConnectionStrings:Default) or env var: ConnectionStrings__Default
var connectionString = builder.Configuration.GetConnectionString("Default")
                      ?? builder.Configuration["ConnectionStrings:Default"]
                      ?? "Host=localhost;Port=5432;Database=basic_crud_db;Username=postgres;Password=postgres";

builder.Services.AddDbContext<AppDbContext>(options =>
{
    // Use Npgsql provider for PostgreSQL
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

// Apply pending migrations automatically on startup (optional for local dev).
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Only redirect HTTP->HTTPS outside of Development.
// In Development it often breaks Swagger due to mixed content or browser rules.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Enable the permissive CORS policy in Development
app.UseAuthorization();
app.MapControllers();

app.Run();
