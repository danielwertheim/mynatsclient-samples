namespace Samples.Subscriber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cnInfo = NatsConfig.GetConnectionInfo();

            //Subscribe using handler
            Sample1.RunAsync(cnInfo).Wait();

            //Automatic unsub
            //Sample2.RunAsync(cnInfo).Wait();

            //Subscribe using observer
            //Sample3.RunAsync(cnInfo).Wait();

            //Observer with exception handlers etc
            //Sample4.RunAsync(cnInfo).Wait();

            //RX, transform, filter, sampling
            //Sample5.RunAsync(cnInfo).Wait();

            //Queue groups (start two or more consumers)
            //Sample6.RunAsync(cnInfo).Wait();

            //Respond to request
            //Sample7.RunAsync(cnInfo).Wait();

            //In-process handler subscription
            //Sample8.RunAsync(cnInfo).Wait();

            //Wildcards (needs SamplePublisherWildcards)
            //Sample9.RunAsync(cnInfo).Wait();

            //Consume JSON (needs SamplePublisherJson)
            //Sample10.RunAsync(cnInfo).Wait();
        }
    }
}
