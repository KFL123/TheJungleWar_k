using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Net;
using System.Net.Sockets;

namespace TCP服务器_0_0_1v
{

    class Program
    {
          static void Main(string[] args)
        {
            StartServerAsync();
            Console.ReadKey();

        }
        static Byte[] dataBuffer = new byte[1024];
        static void StartServerAsync()
        {
            Socket severSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用ipv4和tcp协议
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");//连接本地的
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 58614);//申请端口号
            severSocket.Bind(iPEndPoint);//绑定端口号，像系统申请端口号和地址
            severSocket.Listen(0);//持续性处理客户端
            Socket clientSocket = severSocket.Accept();//接收一个客户端的连接

            string msg = "Hello client ! 你好 ....向每个连接到服务端的客户提供服务";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);
            clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, ReceiveCallBack, clientSocket);//异步接收这是一步的任务
        }
        static void ReceiveCallBack(IAsyncResult ar)
        {

            Socket clientSocket = null;
            try
            {
                clientSocket = ar.AsyncState as Socket;
                int count = clientSocket.EndReceive(ar);
                if (count ==0)
                {
                    clientSocket.Close();
                    return;
                }
                string msg = System.Text.Encoding.UTF8.GetString(dataBuffer, 0, count);
                Console.WriteLine("客户端接收数据：" + msg);
                clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, ReceiveCallBack, clientSocket);//循环执行异步
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                if (clientSocket!=null)
                {
                    clientSocket.Close();
                }
            }
            clientSocket.BeginAccept(AcceptCallBack,clientSocket);
        }
        static void AcceptCallBack(IAsyncResult ar)
        {
            Socket serverSocket = ar.AsyncState as Socket;//类型是相同的能获取socket
            Socket clientSocket = serverSocket.EndAccept(ar);//接收客户端的连接

            string msg = "Hello client ! 你好 ....向每个连接到服务端的客户提供服务";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);
            clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, ReceiveCallBack, clientSocket);//异步接收这是一步的任务


            serverSocket.BeginAccept(AcceptCallBack,serverSocket);//再执行时表示接收多个客户端的请求

        }
    }
}
