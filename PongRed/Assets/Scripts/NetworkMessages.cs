using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Unity.Collections;
using System.Text;
using Unity.Networking.Transport;

namespace NetworkObject {
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

namespace NetworkMessages
{
    public enum Commands { 
        HANDSHAKE,
        READY,
        PLAYERINPUT,
        MOVER_PALA,
        UPDATE_PELOTA
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

    [System.Serializable]
    public class ReadyMsg : NetworkHeader
    {
        public List<NetworkObject.NetworkPlayer> playerList;
        public ReadyMsg()
        {
            command = Commands.READY;
            playerList = new List<NetworkObject.NetworkPlayer>();
        }
    }

    [System.Serializable]
    public class PlayerInputMsg : NetworkHeader
    {
        public string id;
        public string myInput;
        public PlayerInputMsg()
        {
            command = Commands.PLAYERINPUT;
            myInput = "";
            id = "0";

        }
    }

    [System.Serializable]
    public class MoverPalaMsg: NetworkHeader
    {
        public NetworkObject.NetworkPlayer jugador;
        public MoverPalaMsg()
        {
            jugador = new NetworkObject.NetworkPlayer();
            command = Commands.MOVER_PALA;
        }
        
    }

    [System.Serializable]
    public class UpdatePelotaMsg : NetworkHeader
    {
        public Vector3 posPelota;
        public UpdatePelotaMsg()
        {
           command = Commands.UPDATE_PELOTA;
            posPelota = Vector3.zero;
        }

    }


}



