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

                //RX using e.g. Transform, Filter and Sampling
                //Select messages that are longer than 3 and pick
                //the last known each 5th second
                await client.SubWithObservableSubscriptionAsync(
                    "demo",
                    msgOps => msgOps
                        .Select(msgOp => msgOp.GetPayloadAsString())
                        .Where(msg => msg.Length > 3)
                        .Sample(TimeSpan.FromSeconds(5))
                        .Subscribe(Console.WriteLine));

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}