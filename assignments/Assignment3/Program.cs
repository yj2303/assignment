
using Assignment3.Models;
using Assignment3.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;


namespace Assignment3
{
    public class Program
    {
    //   SqlConnection = SqlConnection("Server=localhost;Database=flightbooking;Trusted_Connection=true;MultipleActiveResultSets=true;");
         
    public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
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
        }
    }
}