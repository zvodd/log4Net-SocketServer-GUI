using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSRemoteLog4net
{


    public class SocketLogServer(int port)
    {
        private readonly int _port = port;
        public List<string> logs = [];
        public delegate void LogUpdatedEventHandler(object sender, string logMessage);
        public event LogUpdatedEventHandler LogUpdated = delegate { };

        public delegate void ClientConnectedHandler(object sender, TcpClient client);
        public event ClientConnectedHandler ClientConnected = delegate { };

        public void Start()
        {
            TcpListener listener = new(IPAddress.Any, _port);
            listener.Start();
            Console.WriteLine($"Server started on port {_port}...");

            while (true)
            {
                using (TcpClient client = listener.AcceptTcpClient())
                {
                    OnClientConnected(client);
                    using (NetworkStream stream = client.GetStream())
                    {
                        BinaryFormatter formatter = new();
                        object obj = formatter.Deserialize(stream);

                        if (obj is LoggingEvent loggingEvent)
                        {
                            string logMessage = loggingEvent.Message;
                            logs.Add(logMessage);
                            OnLogUpdated(logMessage);
                        }
                        else
                        {
                            Console.WriteLine("Unknown message received.");
                        }
                    }
                }
            }
        }

        protected virtual void OnLogUpdated(string logMessage)
        {
            LogUpdated?.Invoke(this, logMessage);
        }

        protected virtual void OnClientConnected(TcpClient client)
        {
            ClientConnected?.Invoke(this, client);
        }
    }

    // Assuming LoggingEvent is defined somewhere accessible to both client and server
    public class LoggingEvent
    {
        public string Message { get; set; } = "";
    }

}
