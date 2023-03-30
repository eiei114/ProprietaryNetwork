using KaymakNetwork;

namespace JisakuSerevr
{
    internal static class NetworkSend
    {
        enum ServerPackets
        {
            SWelcomeMsg = 1,
        }
        
        public static void WelcomeMsg(int connectId, string msg)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ServerPackets.SWelcomeMsg);
            buffer.WriteString(msg);
            NetworkConfig.socket.SendDataTo(connectId, buffer.Data,buffer.Head);
            
            buffer.Dispose();
        }
    }
}