using System;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Subscriber
{
    public static class Sample6
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Sample6", cnInfo))
            {
                client.Connect();

                //Queue groups (start two or more consumers)
                var subInfo = new SubscriptionInfo("demo", queueGroup: "Grp1");
                await client.SubWithHandlerAsync(
                    subInfo,
                    msgOp => Console.WriteLine(msgOp.GetPayloadAsString()));

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}