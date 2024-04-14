
using Microsoft.EntityFrameworkCore;

namespace NotYourAverageBicepShoppingApp.ProductsRestAPI
{
    /// <summary>
    /// Represents the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<NotYourAverageBicepShoppingApp.ProductsRestAPI.Models.NotYourAverageBicepContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("CRUDConnection"));
                });

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
