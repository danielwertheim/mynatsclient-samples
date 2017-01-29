namespace Samples.Publisher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Shows possible connection options

            //var cnInfo = new ConnectionInfo("somehost", 4222) //You can pass many hosts in a cluster as well
            //{
            //    //AutoReconnectOnFailure = true
            //    //AutoRespondToPing = true
            //    //Credentials = Credentials.Empty
            //    //PubFlushMode = PubFlushMode.Auto
            //    //RequestTimeoutMs =
            //    //SocketOptions = 
            //    //Verbose = false
            //};

            var cnInfo = NatsConfig.GetConnectionInfo();

            SamplePublisher.RunAsync(cnInfo).Wait();

            //SamplePubMany.RunAsync(cnInfo).Wait(); //Can use Sample11 to measure with NATS TOP

            //SampleRequester.RunAsync(cnInfo).Wait(); //Run with Sample7

            //SamplePublisherWildcards.RunAsync(cnInfo).Wait(); // Run with Sample 8, 9

            //SamplePublisherJson.RunAsync(cnInfo).Wait(); //Run with Sample10
        }
    }
}
