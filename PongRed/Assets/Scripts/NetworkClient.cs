using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Unity.Collections;
using System.Text;
using Unity.Networking.Transport;
using UnityEngine.UI;
using System;
using NetworkMessage;
using NetworkObject;

public class NetworkClient : MonoBehaviour
{

    public NetworkDriver m_Driver;
    public NetworkConnection m_connection;
    private bool empezar = false;

    [Header("IP del servidor")]
    public string serverIP;
    [Header("Puerto a la escucha")]
    public ushort serverPort;
    [Header("InputBox - (Escribir Usuario)")]
    public InputField inputNombre;

    public string idPlayer;


    // Start is called before the first frame update
    public void Conectar()
    {
        m_Driver = NetworkDriver.Create();
        m_connection = default(NetworkConnection);
        var endpoint = NetworkEndPoint.Parse(serverIP, serverPort);
        m_connection = m_Driver.Connect(endpoint);

        inputNombre.gameObject.SetActive(false);
        GameObject.Find("Button").SetActive(false);
        GameObject.Find("Text").GetComponent<Text>().text = "Esperando";
        empezar = true;
    }

    // Update is called once per frame
    void Update()
    {
        m_Driver.ScheduleUpdate().Complete();
        if(!m_connection.IsCreated)
        {
            return;
        }

        DataStreamReader stream;
        NetworkEvent.Type cmd = m_connection.PopEvent(m_Driver, out stream);

        while(cmd != NetworkEvent.Type.Empty)
        {
            if(cmd==NetworkEvent.Type.Connect)
            {
                OnConnect();
            }
            else if(cmd == NetworkEvent.Type.Data)
            {
                OnData(stream);
            }
            else if (cmd == NetworkEvent.Type.Disconnect)
            {

            }
            cmd = m_connection.PopEvent(m_Driver, out stream);
        }
    }

    private void OnConnect()
    {
        Debug.Log("Conectado Correctamente");
    }

    private void OnData(DataStreamReader stream)
    {
        NativeArray<byte> bytes = new NativeArray<byte>(stream.Length, Allocator.Temp);
        stream.ReadBytes(bytes);
        string recMsg = Encoding.ASCII.GetString(bytes.ToArray());
        NetworkHeader header = JsonUtility.FromJson<NetworkHeader>(recMsg);

        switch(header.command)
        {
            case Commands.HANDSHAKE:
                HandshakeMsg mensajeRecibido = JsonUtility.FromJson<HandshakeMsg>(recMsg);

                //Asigno la ID de la conexión en cliente para después enviar mensajes
                idPlayer = mensajeRecibido.player.id;
                //Genero un nuevo mensaje para enviar la información al servidor
                HandshakeMsg mensajeEnviar = new HandshakeMsg();
                mensajeEnviar.player.nombre = inputNombre.text;

                SendToServer(JsonUtility.ToJson(mensajeEnviar));
                break;
            default:
                Debug.Log("Mensaje desconocido");
                break;
        }
    }

    private void SendToServer(string v)
    {
        DataStreamWriter writer;
        m_Driver.BeginSend(NetworkPipeline.Null, m_connection, out writer);
        NativeArray<byte> bytes = new
            NativeArray<byte>(Encoding.ASCII.GetBytes(v), Allocator.Temp);
        writer.WriteBytes(bytes);
        m_Driver.EndSend(writer);
    }
}
