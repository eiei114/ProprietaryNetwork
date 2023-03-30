using System;
using KaymakNetwork.Network;

namespace JisakuSerevr
{
    internal static class NetworkConfig
    {
        private static Server _socket;

        internal static Server socket
        {
            get => _socket;
            set
            {
                if (_socket != null)
                {
                    _socket.ConnectionReceived -= Socket_ConnectionReceived;
                    _socket.ConnectionLost -= Socket_ConnectionLost;
                }

                _socket = value;

                if (_socket != null)
                {
                    _socket.ConnectionReceived += Socket_ConnectionReceived;
                    _socket.ConnectionLost += Socket_ConnectionLost;
                }
            }
        }

        internal static void Initialize()
        {
            if (!(socket == null))
                return;

            socket = new Server(100)
            {
                BufferLimit = 2048000,
                PacketAcceptLimit = 100,
                PacketDisconnectCount = 150,
            };

            NetworkReceive.PacketRouter();
        }

        internal static void Socket_ConnectionReceived(int connectionId)
        {
            
            Console.WriteLine($"Connection received: {connectionId}");
            NetworkSend.WelcomeMsg(connectionId, "自作serverへようこそ！！");
        }

        internal static void Socket_ConnectionLost(int connectionId)
        {
            Console.WriteLine($"Connection lost: {connectionId}");
        }
    }
}