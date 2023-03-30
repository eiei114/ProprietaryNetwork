using System;
using KaymakNetwork;

namespace JisakuSerevr
{
    enum ClientPacket
    {
        CPing = 1,
    }
    internal static class NetworkReceive
    {
        internal static void PacketRouter()
        {
            NetworkConfig.socket.PacketId[(int)ClientPacket.CPing] = Packet_Ping;
        }

        private static void Packet_Ping(int connectionId, ref byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer(data);
            string message = buffer.ReadString();
            
            Console.WriteLine($"Ping received from {connectionId}: {message}");
            
            buffer.Dispose();
        }
    }
}