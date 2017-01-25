using MyNatsClient;

namespace Samples
{
    public static class NatsConfig
    {
        public static ConnectionInfo GetConnectionInfo()
            => new ConnectionInfo("ubuntu01");
    }
}