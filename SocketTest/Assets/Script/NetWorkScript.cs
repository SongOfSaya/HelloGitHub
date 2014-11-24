using UnityEngine;
using System.Collections;
using System.Net.Sockets;

public class NetWorkScript
{
    private static NetWorkScript _instance;
    private Socket _socket;
    //
    private string ip = "127.0.0.1";
    private int port = 10;
    private byte[] buff;

    public static NetWorkScript getInstance()
    {
        if (_instance == null)
        {
            _instance = new NetWorkScript();
        }
        return _instance;
    }

    public void init()
    {
        try
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(ip, port);
            Debug.Log("服务器连接成功");
            _socket.BeginReceive(buff, 0, 1024, SocketFlags.None)
        }
        catch 
        {
            Debug.Log("服务器连接失败");
        }
    }
}
