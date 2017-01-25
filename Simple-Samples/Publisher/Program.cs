namespace Samples.Publisher
{
    public class Program
    {
        public static void Main(string[] args)
        {
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

            //SamplePublisherWildcards.RunAsync(cnInfo).Wait();

            //SampleRequester.RunAsync(cnInfo).Wait(); //Run with Sample7

            //SamplePublisherJson.RunAsync(cnInfo).Wait(); //Run with Sample10
        }
    }
}
