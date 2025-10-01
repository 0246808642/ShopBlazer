using Microsoft.EntityFrameworkCore;
using ShopBlazor.Api.Data;
using ShopBlazor.Api.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conectando com o banco de dados PostgresSQL
builder.Services.AddDbContext<AppDbContext>(op=> op.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));

// Injetando o repositório
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
