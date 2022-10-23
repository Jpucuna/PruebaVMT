using EsquemaPrueba.Interfaces;
using EsquemaPrueba.Models;
using EsquemaPrueba.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//SECCION DE DEFINICION PARA LA CONEXION SQL---------------------------------------

const string sqlConection = "Conexion";

var conexionString = builder.Configuration.GetConnectionString(sqlConection);

builder.Services.AddDbContext<dbContext>(options => options.UseSqlServer(conexionString));

//SECCION DE DEFINICION PARA LA CONEXION SQL---------------------------------------



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PersonaInterface, PersonaService>();
builder.Services.AddScoped<UsuarioInterface, UsuarioService>();



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
