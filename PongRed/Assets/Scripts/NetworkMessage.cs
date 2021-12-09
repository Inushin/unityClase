using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Unity.Collections;
using System.Text;
using Unity.Networking.Transport;

namespace NetworkObject
{
    [System.Serializable]
    public class NetworkObject
    {
        public string id;
    }

    [System.Serializable]
    public class NetworkPlayer:NetworkObject
    {
        public Vector3 posJugador;
        public string nombre;
    }

}

namespace NetworkMessage
{
    public enum Commands
    {
        HANDSHAKE
    }

    [System.Serializable]
    public class NetworkHeader
    {
        public Commands command;
    }

    [System.Serializable]
    public class HandshakeMsg : NetworkHeader
    {
        public NetworkObject.NetworkPlayer player;

        public HandshakeMsg()
        {
            command = Commands.HANDSHAKE;
            player = new NetworkObject.NetworkPlayer();
        }
    }

}