using System;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Publisher
{
    public static class SamplePublisher
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

                    await client.PubAsync("demo", message);
                }
            }
        }
    }
}