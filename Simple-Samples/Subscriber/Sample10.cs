using System;
using System.Threading.Tasks;
using MyNatsClient;
using MyNatsClient.Encodings.Json;

namespace Samples.Subscriber
{
    public static class Sample10
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Sample1", cnInfo))
            {
                client.Connect();

                //Consume JSON
                await client.SubWithHandlerAsync(
                    "demo.greeting",
                    msg =>
                    {
                        var greeting = msg.FromJson<Greeting>();

                        Console.WriteLine($"{greeting.SentBy} said: {greeting.Message}");
                    });

                Console.WriteLine("Hit key to quit.");
                Console.ReadKey();
            }
        }

        private class Greeting
        {
            public string Message { get; set; }
            public string SentBy { get; set; }
        }
    }
}