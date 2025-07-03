using System;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcDemo;

namespace GrpcServer
{
    class Program
    {
        const int Port = 50051;

        static void Main(string[] args)
        {
            var server = new Server
            {
                Services = { Greeter.BindService(new GreeterImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.WriteLine("gRPC server listening on port " + Port);
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }

    public class GreeterImpl : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello, " + request.Name
            });
        }
    }
}