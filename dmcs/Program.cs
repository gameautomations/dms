using dm;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MyTcpListener
{
    public static void Main()
    {
        TcpListener server = null!;
        try
        {
            int port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(localAddr, port);
            server.Start();

            // 接受客户端连接
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                var t = new Thread(() =>
                {
                    HandleConnection(client);

                });
                t.Start();
            }
        }
        catch (SocketException e)
        {
            //
        }
        finally
        {
            server.Stop();
        }
        Console.Read();
    }

    public static void HandleConnection(object obj)
    {
        TcpClient? client = null;
        NetworkStream? stream = null;
        Dmsoft? dmsoft = null;
        try
        {
            client = (TcpClient)obj;
            stream = client.GetStream();
            dmsoft = new Dmsoft();

            // 接收客户端消息
            while (true)
            {
                var bytes = new byte[256];
                int i = stream.Read(bytes, 0, bytes.Length);
                var data = Encoding.UTF8.GetString(bytes, 0, i);
                Console.WriteLine("Received: {0}", data);

                // Process the data sent by the client.
                data = data.ToUpper() + dmsoft.DM.Ver() + "---" +  dmsoft.DM.GetDmCount();

                byte[] msg = Encoding.UTF8.GetBytes(data);

                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", data);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            stream?.Close();
            stream?.Dispose();
            client?.Close();
            client?.Dispose();
            dmsoft?.Rlease();
        }
    }
}