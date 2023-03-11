using Microsoft.EntityFrameworkCore;
using MultiInquilino.Fx.Extensiones;
using MultiInquilinoUnicaBaseDatos.MultiTenancy;
using MultiInquilinoUnicaBaseDatos.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMemoryCache();

builder.Services.AddMultiTenancy()
    .WithResolutionStrategy<HostResolutionStrategy>()
    .WithStore<DbContextTenantStore>();

builder.Services.AddDbContext<TenantAdminDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TenantAdmin")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMultiTenancy(); // <--- custom middleware

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
