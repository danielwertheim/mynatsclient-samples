using System;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Subscriber
{
    public static class Sample11
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            var n = 0;

            using (var client = new NatsClient("Sample1", cnInfo))
            {
                client.Connect();

                //Subscribe using handler (action)
                await client.SubWithHandlerAsync(
                    "demo",
                    msg => n++);

                Console.WriteLine("Hit key to show num of received messages.");
                Console.ReadKey();
            }

            Console.WriteLine(n);
            Console.ReadKey();
        }
    }
}