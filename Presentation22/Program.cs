
using Microsoft.EntityFrameworkCore;
using Models.Data;
using Repos.Repos;
using Repos.Services;

namespace Presentation22
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Apppdbcontext>(
                options =>
                {
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("constr")
                        );
                }
                
                );
            builder.Services.AddScoped<ITask1,Task1Repo>();
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("mycors", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
               
            });

            // Add services to the container.

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
            app.UseCors("mycors");


            app.MapControllers();

            app.Run();
        }
    }
}
