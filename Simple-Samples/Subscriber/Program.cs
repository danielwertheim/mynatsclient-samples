namespace Samples.Subscriber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cnInfo = NatsConfig.GetConnectionInfo();

            //Subscribe using handler
            Sample1.RunAsync(cnInfo).Wait();

            //Automatic unsub after 3 messages
            //Sample2.RunAsync(cnInfo).Wait();

            //Subscribe using observer
            //Sample3.RunAsync(cnInfo).Wait();

            //Observer with exception handlers etc
            //Sample4.RunAsync(cnInfo).Wait();

            //RX, transform, filter, sampling
            //Sample5.RunAsync(cnInfo).Wait();

            //Queue groups (NEEDS two or more consumers)
            //Randomizes
            //Sample6.RunAsync(cnInfo).Wait();

            //Respond to request (NEEDS SampleRequester)
            //Sample7.RunAsync(cnInfo).Wait();

            //In-process handler subscription with wildcards
            //(NEEDS SamplePublisherWildcards) against
            //"demo.a" and "demo.b"
            //Sample8.RunAsync(cnInfo).Wait();

            //Wildcards (NEEDS SamplePublisherWildcards)
            //Sample9.RunAsync(cnInfo).Wait();

            //Consume JSON (NEEDS SamplePublisherJson)
            //Sample10.RunAsync(cnInfo).Wait();
        }
    }
}
