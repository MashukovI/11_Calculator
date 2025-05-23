using _11_Calculator;
using _11_Calculator.Kafka;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;

namespace _11_Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connStr = builder.Configuration.GetConnectionString("Main");

            builder.Services.AddDbContext<MainDbContext>(opt => opt.UseMySql(connStr, new MySqlServerVersion(new Version(11, 2))));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHostedService<KafkaConsumerService>();
            builder.Services.AddSingleton<KafkaProducerHandler>();
            builder.Services.AddSingleton<KafkaProducerService<Null, string>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Calculator}/{action=Index}/{id?}");

            app.Run();
        }
    }
}