using GTShop.Server.Data;
using GTShop.Server.Extensions;
using GTShop.Server.Models;
using GTShop.Server.Startup;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAppIdentityServices();
builder.Services.AddDbApplicationServices(builder);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    MigrationsExtensions.UpdateMigrations(app);
}

app.UseHttpsRedirection();



app.MapControllers();

app.MapFallbackToFile("/index.html");

app.MapIdentityApi<User>();

app.Run();
