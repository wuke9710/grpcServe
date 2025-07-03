using Grpc.Core;
using GrpcDemo;
using System;
using System.Runtime.Remoting.Channels;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("localhost:50051", ChannelCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);

            var reply = client.SayHello(new HelloRequest { Name = "ChatGPT" });

            Console.WriteLine("Server replied: " + reply.Message);

            channel.ShutdownAsync().Wait();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}