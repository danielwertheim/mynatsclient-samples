using System;
using System.Threading.Tasks;
using MyNatsClient;
using MyNatsClient.Encodings.Json;

namespace Samples.Publisher
{
    public static class SamplePublisherJson
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Publisher", cnInfo))
            {
                client.Connect();

                while (true)
                {
                    Console.WriteLine("Say what? (blank=quit)");
                    var message = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(message))
                        break;

                    await client.PubAsJsonAsync("demo.greeting", new Greeting
                    {
                        Message = message,
                        SentBy = Environment.UserName
                    });
                }
            }
        }

        private class Greeting
        {
            public string Message { get; set; }
            public string SentBy { get; set; }
        }
    }
}