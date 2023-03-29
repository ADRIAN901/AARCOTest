global using APIExamen.Core.Entity;
global using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped(typeof(IServiceProvider<>), typeof(ServiceProvider<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
IWebHostEnvironment env = builder.Environment;

//app.UseStaticFiles();

//app.UseRouting();





app.MapControllers();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/



/*app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});*/

app.Run();
