using ASY.Hrefs.gRPC.Interface;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ASY.Hrefs.MicroServer
{
    public class HostServer : IHostedService
    {
        private readonly ILogger logger;
        private readonly HelloSrv.HelloSrvBase server;
        Server gRPC = null;

        public HostServer(ILogger<HostServer> logger, HelloSrv.HelloSrvBase server)
        {
            this.logger = logger;
            this.server = server;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("服务启动...");
            gRPC = new Server
            {
                Services = { HelloSrv.BindService(server) },
                Ports = { new ServerPort("0.0.0.0", 50088, ServerCredentials.Insecure) }
            };
            gRPC.Start();

            Console.WriteLine("Greeter server listening on port " + 50088);
            Console.WriteLine("Press any key to stop the server...");
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("服务停止...");
            await gRPC.ShutdownAsync();
        }
    }
}