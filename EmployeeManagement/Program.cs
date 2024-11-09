using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace EmployeeManagement;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyCors", builder =>
            {
                builder
                .WithOrigins("http://localhost:4200")// Angular App URL
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });


        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseInMemoryDatabase("EmployeeDb");
        });

        var app = builder.Build();

        app.UseCors("MyCors");

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
