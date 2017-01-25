using System;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Subscriber
{
    public static class Sample7
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Sample7", cnInfo))
            {
                client.Connect();

                //Respond to request
                await client.SubWithHandlerAsync(
                    "demo-request",
                    msgOp =>
                    {
                        var msg = msgOp.GetPayloadAsString();

                        Console.WriteLine($"I got request: {msg}");

                        client.Pub(msgOp.ReplyTo, $"You requested: {msg}");
                    });

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}