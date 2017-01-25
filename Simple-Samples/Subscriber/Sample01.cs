using System;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Subscriber
{
    public static class Sample1
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Sample1", cnInfo))
            {
                client.Connect();

                //Subscribe using handler (action)
                await client.SubWithHandlerAsync(
                    "demo",
                    msg => Console.WriteLine(msg.GetPayloadAsString()));

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}