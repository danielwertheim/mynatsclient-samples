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
            using (var tcp = new System.Net.Sockets.TcpClient())
            {
                tcp.Connect(NatsHost, NatsPort);

                while (true)
                {
                    Console.WriteLine("Send: (Blank to Exit)");
                    var msg = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(msg))
                        break;

                    tcp.Client.Publish(Subject, msg);
                }

                tcp.Close();
            }
        }
    }

    public static class SocketExtensions
    {
        public static void Publish(this Socket socket, string subject, string data)
            => socket.Send(Encode($"pub {subject} {data.Length}\r\n{data}\r\n"));

        private static byte[] Encode(string data)
            => Encoding.UTF8.GetBytes(data);
    }
}
