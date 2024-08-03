using CustomerPortalAPI2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CustomerPortalAPI2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(6, 0, 23)))); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") 
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerPortalAPI2 v1"));
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
