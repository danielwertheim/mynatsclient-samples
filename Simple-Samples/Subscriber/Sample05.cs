using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Subscriber
{
    public static class Sample5
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Sample5", cnInfo))
            {
                client.Connect();

                //RX
                await client.SubWithObservableSubscriptionAsync(
                    "demo",
                    msgOps => msgOps
                        .Select(msgOp => msgOp.GetPayloadAsString())
                        .Where(msg => msg.Length > 5)
                        .Sample(TimeSpan.FromSeconds(5))
                        .Subscribe(Console.WriteLine));

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}