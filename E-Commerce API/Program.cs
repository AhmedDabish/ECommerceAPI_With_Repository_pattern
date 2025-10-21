
using E_Commerce_API.Repositories;
using E_Commerce_API.Data;
using Microsoft.EntityFrameworkCore;
using E_Commerce_API.Profiles;

namespace E_Commerce_API
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

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("mycon")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));
           

            //  builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



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
