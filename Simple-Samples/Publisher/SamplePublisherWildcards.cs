using System;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Publisher
{
    public static class SamplePublisherWildcards
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

                    Console.WriteLine("To what \"Child\" Subject? (blank=quit)");
                    var subject = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(subject))
                        break;

                    await client.PubAsync($"demo.{subject}", message);
                }
            }
        }
    }
}