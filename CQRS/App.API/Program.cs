using App.Application.Features.Students.Commands;
using App.Application.Features.Students.Queries;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace App.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");

            builder.Services.AddInfrastructure(connectionString);

            builder.Services.AddScoped<CreateStudentHandler>();
            builder.Services.AddScoped<GetStudentByIdHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
