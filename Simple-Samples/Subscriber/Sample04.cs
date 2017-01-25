using System;
using System.Threading.Tasks;
using MyNatsClient;
using MyNatsClient.Ops;

namespace Samples.Subscriber
{
    public static class Sample4
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Sample4", cnInfo))
            {
                client.Connect();

                //Observer lets you react on exceptions etc
                await client.SubWithObserverAsync(
                    "demo",
                    new DelegatingObserver<MsgOp>(
                        msg =>
                        {
                            if (client.Stats.OpCount == 5)
                                throw new Exception("Oh no!");

                            Console.WriteLine(msg.GetPayloadAsString());
                        },
                        ex => Console.WriteLine($"Bad times! {ex}")));

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}