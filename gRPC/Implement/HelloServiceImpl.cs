using ASY.Hrefs.BLL.IService;
using ASY.Hrefs.gRPC.Interface;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace ASY.Hrefs.gRPC.Implement
{
    public class HelloServiceImpl : HelloSrv.HelloSrvBase
    {
        IHelloService HelloService;
        public HelloServiceImpl(IHelloService helloService)
        {
            this.HelloService = helloService;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply response = new HelloReply();

            response.Message = this.HelloService.SayHello(request.Name);
            return Task.FromResult(response);
        }
    }
}