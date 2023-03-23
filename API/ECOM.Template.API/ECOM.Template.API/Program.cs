using ECOM.DBAccess.Nuget.Logic.Implementations;
using ECOM.DBAccess.Nuget.Logic.Interfaces;
using ECOM.Template.DataBase.Interfaces;
using ECOM.Template.Services.Implement;
using ECOM.Template.Services.Interfaces;
using ECOM.Template.UserCases.Implement;
using ECOM.Template.UserCases.Interfaces;
using ECOM.Utils.Nuget.Logic.Implementations;
using ECOM.Utils.Nuget.Logic.Interfaces;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHttpContextAccessor();

//Inyección de dependencias
builder.Services.AddScoped<IEjecutaServicio, EjecutaServicio>();
builder.Services.AddScoped<ICallService, CallServiceImplement>();
builder.Services.AddScoped<ICallHttpServices, CallHttpServicesImplement>();
builder.Services.AddScoped<IECOM, ECOM.Template.DataBase.Implement.ECOM>();
builder.Services.AddScoped<IDataAccess, DataAccess>();
builder.Services.AddScoped<IExceptionHandlerFeature, ExceptionHandlerFeature>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

IWebHostEnvironment env = builder.Environment;
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context => 
    {
        await new ErrorHandlingMiddleware(null,
            env,
            exceptionHandlerApp.ApplicationServices.GetService<ILogger<ErrorHandlingMiddleware>>(),
            exceptionHandlerApp.ApplicationServices.GetService<IEmailService>(),
            exceptionHandlerApp.ApplicationServices.GetService<IConfiguration>())
        .HandleExceptionAsync(context, context.Features.Get<IExceptionHandlerFeature>()?.Error);
    });
});
app.UseHsts();
app.MapControllers();


app.Run();
