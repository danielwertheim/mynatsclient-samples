using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using MyNatsClient;
using MyNatsClient.Ops;

namespace Samples.Subscriber
{
    public static class Sample8
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Sample8", cnInfo))
            {
                client.MsgOpStream
                    .Where(msgOp => msgOp.Subject == "demo.a")
                    .Select(msgOp => msgOp.GetPayloadAsString())
                    .Subscribe(msg => Console.WriteLine($"A: {msg}"));

                client.MsgOpStream
                    .Where(msgOp => msgOp.Subject == "demo.b")
                    .Select(msgOp => msgOp.GetPayloadAsString())
                    .Subscribe(msg => Console.WriteLine($"B: {msg}"));

                client.OpStream
                    .OfType<MsgOp>()
                    .Select(msgOp => msgOp.GetAsString().Length)
                    .Subscribe(len => Console.WriteLine($"Len: {len}"));

                client.Connect();

                await client.SubAsync("demo.a");
                await client.SubAsync("demo.b");

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}