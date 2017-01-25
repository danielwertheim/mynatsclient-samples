using System;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Publisher
{
    public static class SampleRequester
    {
        public static async Task RunAsync(ConnectionInfo cnInfo)
        {
            using (var client = new NatsClient("Requester", cnInfo))
            {
                client.Connect();

                while (true)
                {
                    Console.WriteLine("Request what? (blank=quit)");
                    var message = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(message))
                        break;

                    var response = await client.RequestAsync("demo-request", message);
                    Console.WriteLine($"Response: {response.GetPayloadAsString()}");
                }
            }
        }
    }
}