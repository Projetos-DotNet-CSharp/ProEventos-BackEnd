using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// String de conex�o criada no appsettings.json !!!!!!!!!!!!!!!!!!!!!!!
string sqliteConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// Definir o contexto da conex�o (SGBD MySql) !!!!!!!!!!!!!!!!!!!!!!!
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(sqliteConnection)
);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();

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

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();
