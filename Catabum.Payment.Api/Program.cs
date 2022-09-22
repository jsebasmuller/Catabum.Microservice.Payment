using System;
using System.IO;
using Autofac.Extensions.DependencyInjection;
using Figgle;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Catabum.Payment.Api.Infrastructure.Extensions;
using Catabum.Payment.Infrastructure;
using Catabum.Payment.Api.Infrastructure.Seeding;
using Catabum.Payment.Api.SeedWork;
using Serilog;

namespace Catabum.Payment.Api
{
    public static class Program
    {
        public static readonly string ServiceName = "Catabum PaymentService. ";

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(FiggleFonts.Standard.Render(ServiceName));
                var host = CreateHostBuilder(args).Build();
                
                host.MigrateDatabase<PaymentsContext>((context, services) =>
                {
                    // new UsersContextSeed(services)
                    //     .SeedAsync()
                    //     .Wait();
                });
                
                //PersistedGrantDbContext
                
                host.MigrateDatabase<PersistedGrantDbContext>((context, services) =>
                {
                });
                
                //ConfigurationDbContext
                host.MigrateDatabase<ConfigurationDbContext>((context, services) =>
                {
                     new IdentityServerSeed()
                         .InitializeDatabaseAsync(services)
                         .Wait();
                });
                
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "{@ServiceName} terminated unexpectedly ({ApplicationContext})!", ServiceName);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.Sources.Clear();
                    var env = hostingContext.HostingEnvironment;
                    config.SetBasePath(Directory.GetCurrentDirectory() + "/Configuration")
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile(ConfigMapFileProvider.FromRelativePath("/Configuration"),
                            $"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseIISIntegration()
                        .UseStartup<Startup>();
                });
    }
}