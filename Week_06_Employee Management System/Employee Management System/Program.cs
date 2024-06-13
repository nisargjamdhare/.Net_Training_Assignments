using Microsoft.Azure.Cosmos;
using Employee_Management_System.Services;
using EmployeeManagementSystem.Interface;
using EmployeeManagementSystem.Services;
using Microsoft.Bot.Configuration;
using EmployeeManagementSystem.CosmoDB;

namespace Employee_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register Cosmos DB Client
            builder.Services.AddSingleton<ICosmoDBService, ICosmoDBService>();
            builder.Services.AddSingleton<ExcelService>();
            builder.Services.AddScoped<IEmployeeBasicDetailsService, EmployeeBasicDetailsService>();
            builder.Services.AddScoped<IEmployeeAdditionalDetailsService, EmployeeAdditionalDetailsService>();

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
        }
    }
}
