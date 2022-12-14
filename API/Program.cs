using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //Logger factory will create instance of the Logger class
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<StoreContext>();
                    //Apply pending migrations to the database
                    await context.Database.MigrateAsync();
                    //Seed the data when app starts
                    await StoreContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
