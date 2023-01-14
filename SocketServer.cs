using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using SocketIOClient;
using System.Collections.Generic;





public class SocketServer
{

    private SocketIO socket;


    private static SocketServer instance;

    private List<string> messages = new List<string>();

    public SocketIO GetSocket()
    {
        return socket;
    }
    public async void ConnectToServer(string ipAddress, int port)
    {
        try
        {

            IPAddress serverIP = IPAddress.Parse(ipAddress);

            // string serverURI = $"http://{serverIP}:{port}";
            string serverURI = $"http://192.168.179.36:{port}";


            socket = new SocketIO(serverURI);

        

            socket.OnConnected += (sender, e) =>
            {
                Console.WriteLine("Conexión establecida");
            };
            await socket.ConnectAsync(); 
 
        }
        catch (SocketException ex)
        {
            MessageBox.Show("Error connecting to server: " + ex.Message);
        }


    }

    public static SocketServer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SocketServer();
            }
            return instance;
        }
    }

    public SocketServer()
	{
	}
}
