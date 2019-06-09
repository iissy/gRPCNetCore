using ASY.Hrefs.BLL.IService;
using ASY.Hrefs.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASY.Hrefs.BLL.Service
{
    public class HelloService : IHelloService
    {
        IHelloRepository HelloRepository;
        public HelloService(IHelloRepository helloRepository)
        {
            this.HelloRepository = helloRepository;
        }

        public string SayHello(string message)
        {
            return this.HelloRepository.SayHello(message);
        }
    }
}