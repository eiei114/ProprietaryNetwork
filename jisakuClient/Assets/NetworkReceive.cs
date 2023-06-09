﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaymakNetwork;
using UnityEngine;

enum ServerPackets
{
    SWelcomeMsg = 1,
}

internal static class NetworkReceive
{
    internal static void PacketRouter()
    {
        NetworkConfig.socket.PacketId[(int)ServerPackets.SWelcomeMsg] = new KaymakNetwork.Network.Client.DataArgs(Packet_WelcomeMsg);
    }
            
    private static void Packet_WelcomeMsg(ref byte[] data)
    {
        ByteBuffer buffer = new ByteBuffer(data);
        string msg = buffer.ReadString();
        buffer.Dispose();

        Debug.Log(msg);

        NetworkSend.SendPing();
    }
}

