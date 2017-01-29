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
                //Queue groups means balancing as only one in the
                //group will get it.
                //NOTE! Others consumers on the same subject will also
                //get the message.
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