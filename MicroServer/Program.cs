using ASY.Hrefs.BLL.IService;
using ASY.Hrefs.BLL.Service;
using ASY.Hrefs.DAL.IRepository;
using ASY.Hrefs.DAL.Repository;
using ASY.Hrefs.gRPC.Implement;
using ASY.Hrefs.gRPC.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ASY.Hrefs.MicroServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.AddJsonFile("appsettings.json", true);
                    configApp.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true);
                    configApp.AddEnvironmentVariables();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging();
                    services.AddOptions();
                    services.AddSingleton<HelloSrv.HelloSrvBase, HelloServiceImpl> ();
                    services.AddTransient<IHelloService, HelloService>();
                    services.AddTransient<IHelloRepository, HelloRepository>();
                    services.AddHostedService<HostServer>();
                })
                .ConfigureLogging((hostContext, configLogging) =>
                {
                    configLogging.AddConsole();
                })
                .UseConsoleLifetime()
                .Build();

            host.Run();
        }
    }
}