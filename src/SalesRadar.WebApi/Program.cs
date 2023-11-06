using SalesRadar.Infrastruture;
using Microsoft.EntityFrameworkCore;
using SalesRadar.Common;
using SalesRadar.Application.Contracts;
using SalesRadar.Application.Services;
using SalesRadar.Domain.Contracts;
using SalesRadar.Infrastruture.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();

builder.Services.AddLiteDb("sales.db");


builder.Services.AddScoped<ICustomerService, CustomerService>();

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
