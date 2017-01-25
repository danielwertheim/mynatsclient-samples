using System;
using System.Threading.Tasks;
using MyNatsClient;
using MyNatsClient.Ops;

namespace Samples.Subscriber
{
    public static class Sample3
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Sample3", cnInfo))
            {
                client.Connect();

                //Subscribe with observer
                await client.SubWithObserverAsync(
                    "demo",
                    new DelegatingObserver<MsgOp>(
                        msg => Console.WriteLine(msg.GetPayloadAsString())));

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}