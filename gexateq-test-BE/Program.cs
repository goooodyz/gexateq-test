
using gexateq_test_BE.Database;
using gexateq_test_BE.Services.EmployeeService;
using Microsoft.EntityFrameworkCore;

namespace gexateq_test_BE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });


            builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            var app = builder.Build();

            app.UseCors("AllowLocalhost");

            var apiGroup = app.MapGroup("/api");

            app.RegisterEndpoints(apiGroup);

            app.Run();
        }
    }
}
