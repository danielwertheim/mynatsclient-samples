using System;
using System.Net.Sockets;
using System.Text;

namespace TcpClient
{
    class Program
    {
        private const string NatsHost = "ubuntu01";
        private const int NatsPort = 4222;
        private const string Subject = "test";

        static void Main(string[] args)
        {
            //Connect to NATS Server using TCPClient.
            using (var tcp = new System.Net.Sockets.TcpClient())
            {
                tcp.Connect(NatsHost, NatsPort);

                while (true)
                {
                    Console.WriteLine("Send: (Blank to Exit)");

                    var message = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(message))
                        break;

                    //Use extension method below to send message
                    tcp.Client.Publish(Subject, message);
                }

                tcp.Close();
            }
        }
    }

    public static class SocketExtensions
    {
        //http://nats.io/documentation/internals/nats-protocol/#PUB
        //PUB <subject> [reply-to] <#bytes>\r\n[payload]\r\n
        public static void Publish(this Socket socket, string subject, string data)
            => socket.Send(Encode($"pub {subject} {data.Length}\r\n{data}\r\n"));

        private static byte[] Encode(string data)
            => Encoding.UTF8.GetBytes(data);
    }
}
