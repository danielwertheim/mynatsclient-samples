using System;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Subscriber
{
    public static class Sample2
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Sample2", cnInfo))
            {
                client.Connect();

                //Subsribe and unsub after 3 messages
                var subInfo = new SubscriptionInfo("demo", maxMessages: 3);
                await client.SubWithHandlerAsync(
                    subInfo,
                    msg => Console.WriteLine(msg.GetPayloadAsString()));

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}