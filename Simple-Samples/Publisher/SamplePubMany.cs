using System;
using System.Threading.Tasks;
using MyNatsClient;

namespace Samples.Publisher
{
    public static class SamplePubMany
    {
        public static Task RunAsync(ConnectionInfo cnInfo)
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

                    int n;
                    Console.WriteLine("How many? (blank=quit)");
                    if(!int.TryParse(Console.ReadLine(), out n))
                        break;

                    client.PubMany(p =>
                    {
                        for (var c = 0; c < n; c++)
                            p.Pub("demo", message);
                    });
                }
            }

            return Task.CompletedTask;
        }
    }
}