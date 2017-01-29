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
                //Send "fail" to have it fail
                await client.SubWithObserverAsync(
                    "demo",
                    new DelegatingObserver<MsgOp>(
                        msgOp =>
                        {
                            var msg = msgOp.GetPayloadAsString();

                            if (msg == "fail")
                                throw new Exception("Oh no!");

                            Console.WriteLine(msg);
                        },
                        ex => Console.WriteLine($"Bad times! {ex}")));

                //You can have an "generic" handler for exceptions as well
                client.MsgOpStream.OnException = (msgOp, ex) =>
                    Console.WriteLine($"Worse times! {ex}");

                //If logging is all you need you can also hook into
                //LoggerManager.Resolve

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}