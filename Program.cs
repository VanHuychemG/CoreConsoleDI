using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreConsoleDI.Domain.Configuration;
using CoreConsoleDI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreConsoleDI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var app = serviceProvider.GetService<Application>();

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var loggerFactory = new LoggerFactory()
                .AddConsole()
                .AddDebug();

            services.AddSingleton(loggerFactory);
            services.AddLogging();

            var configuration = GetConfiguration();
            services.AddSingleton<IConfiguration>(configuration);

            services.AddOptions();
            services.Configure<FooConfiguration>(configuration.GetSection("Foo"));
            services.Configure<BarConfiguration>(configuration.GetSection("Bar"));

            services.AddSingleton<IFooService, FooService>();
            services.AddSingleton<IBarService, BarService>();
            services.AddTransient<Application>();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true);

            return configuration.Build();
        }
    }
}
