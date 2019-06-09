using ASY.Hrefs.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASY.Hrefs.DAL.Repository
{
    public class HelloRepository : IHelloRepository
    {
        public string SayHello(string message)
        {
            return message + "world!";
        }
    }
}