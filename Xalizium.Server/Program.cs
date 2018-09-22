using Lidgren.Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xalizium.Server
{
    class Program
    {
        static NetServer server;

        static void Main(string[] args)
        {
            NetPeerConfiguration config = new NetPeerConfiguration("Xalizium");
            config.Port = 7777;

            server = new NetServer(config);

            server.Start();
            Console.WriteLine("Server Started!");

            new Thread(() => 
            {
                int count = 0;

                while (true)
                {
                    if (server.ConnectionsCount != count)
                    {
                        OnConnectionChanged();
                        count = server.ConnectionsCount;
                    }
                    Thread.Sleep(1000);
                }
            }).Start();

            NetIncomingMessage msg;
            while ((msg = server.ReadMessage()) != null)
            {
                switch (msg.MessageType)
                {
                    case NetIncomingMessageType.VerboseDebugMessage:
                    case NetIncomingMessageType.DebugMessage:
                    case NetIncomingMessageType.WarningMessage:
                    case NetIncomingMessageType.ErrorMessage:
                        Console.WriteLine(msg.ReadString());
                        break;
                    case NetIncomingMessageType.ConnectionApproval:

                        break;
                    case NetIncomingMessageType.Data:
                        ParseData(msg.ReadString());
                        break;
                    default:
                        Console.WriteLine("Unhandled type: " + msg.MessageType);
                        break;
                }
                server.Recycle(msg);
            }
        }

        static void OnConnectionChanged()
        {

        }

        static void ParseData(string dp)
        {
            DataPackage package = JsonConvert.DeserializeObject<DataPackage>(dp);
            // Handle All The Stuff
        }
    }
}
