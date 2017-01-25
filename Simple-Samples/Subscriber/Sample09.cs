using System;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Subscriber
{
    public static class Sample9
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Sample9", cnInfo))
            {
                client.Connect();

                //Setup wildcard sub
                await client.SubWithHandlerAsync(
                    "demo.>",
                    msgOp => Console.WriteLine($"(1): {msgOp.Subject}:{msgOp.GetPayloadAsString()}"));

                await client.SubWithHandlerAsync(
                    "demo.*",
                    msgOp => Console.WriteLine($"(2): {msgOp.Subject}:{msgOp.GetPayloadAsString()}"));

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}