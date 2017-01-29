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
                //Subscribe directly to MsgOpStream
                client.MsgOpStream
                    .Where(msgOp => msgOp.Subject == "demo.a")
                    .Select(msgOp => msgOp.GetPayloadAsString())
                    .Subscribe(msg => Console.WriteLine($"A: {msg}"));

                client.MsgOpStream
                    .Where(msgOp => msgOp.Subject == "demo.b")
                    .Select(msgOp => msgOp.GetPayloadAsString())
                    .Subscribe(msg => Console.WriteLine($"B: {msg}"));

                //OpStream gets all incoming Ops. Like MsgOp, Ping, Pong...
                client.OpStream
                    .OfType<MsgOp>()
                    .Select(msgOp => msgOp.GetAsString().Length)
                    .Subscribe(len => Console.WriteLine($"Len: {len}"));

                client.Connect();

                //Tell NATS server we are interested in all subjects
                //under "demo". So we only have one NATS Server subscription
                await client.SubAsync("demo.>");

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }
    }
}