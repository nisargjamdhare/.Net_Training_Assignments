using AutoMapper;
using EmployeeManagementSystem25.Common;
using EmployeeManagementSystem25.CosmosDB;
using EmployeeManagementSystem25.Interfaces;
using EmployeeManagementSystem25.ServiceFilters;
using EmployeeManagementSystem25.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementSystem25
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEmployeeBasicDetailsService, EmployeeBasicDetailsService>();
            builder.Services.AddScoped<IEmployeeAdditionalDetailsService , EmployeeAdditionalDetailsService>();
            builder.Services.AddScoped<ICosmosDBService, CosmosDBService>();
            builder.Services.AddScoped<IManagerService, ManagerService>();

            // Register AutoMapper with the provided profiles
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddScoped<BuildEmployeeFilter>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
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
