using Microsoft.EntityFrameworkCore;
using shop.Application.Contract;
using shop.Application.Service;
using shop.Infraestructure.Context;
using shop.Infraestructure.Interfaces;
using shop.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// registro de dependencia //
builder.Services.AddDbContext<shopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("shopContext")));

// repositorios //

builder.Services.AddTransient<IProductRepository, ProductRepository>();

// registros de app services //

builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
