using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.eShopWeb.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Microsoft.eShopWeb.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                        .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var catalogContext = services.GetRequiredService<CatalogContext>();
                    CatalogContextSeed.SeedAsync(catalogContext, loggerFactory)
            .Wait();

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    AppIdentityDbContextSeed.SeedAsync(userManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public void Unused(int a) {
            if (a == 1) {
                 Console.WriteLine("one");
                 
                 Console.WriteLine("one");
                 
                 Console.WriteLine("one");
                 
                 Console.WriteLine("one");
                 
                 Console.WriteLine("one");
                 
                 Console.WriteLine("one");
            } else {
                 Console.WriteLine("not one");

                 Console.WriteLine("not one");

                 Console.WriteLine("not one");

                 Console.WriteLine("not one");

                 Console.WriteLine("not one");

                 Console.WriteLine("not one");

                 Console.WriteLine("not one");
            }
        }

        public void Execute()
        {
            int sum = 0;
            for(int i = 0; i < 10; i++)
            {
                if (i != 0 ) {
                    sum++;
                }
            }
        }

        public void NewMethod() {


        }

        public static string SocalSecurityNumber = "123-45-6789";

        public static string CreditCardNumber = "4916784487431276"; // VISA

        public static string ChangePassword = "Password@1";

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
