//using ECOM.Template.MinAPI.Filters;
using ECOM.Template.MinAPI.InitVariables;
using ECOM.Template.UserCases.Implement;
using ECOM.Template.UserCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext
var securityScheme = new OpenApiSecurityScheme
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "Seguridad basada en JSON Web Token"
};

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEjecutaServicio, EjecutaServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("ECOM/Gateway/Get/{Metodo}", async ([FromServices] IEjecutaServicio _ejecutaServicio, string Metodo) =>
{
    //Retorna valor de búsqueda
    return await _ejecutaServicio.GeneraPeticion(InitVariables.Parameters, InitVariables.PathBase, 0, InitVariables.Headers).ConfigureAwait(false);
});

app.Run();