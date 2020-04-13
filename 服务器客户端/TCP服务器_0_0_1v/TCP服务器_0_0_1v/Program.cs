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
        static Message msg = new Message();
        static Byte[] dataBuffer = new byte[1024];
        static void Main(string[] args)
        {
            StartServerAsync();
            Console.ReadKey();

        }

        static void StartServerAsync()
        {
            Socket severSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//使用ipv4和tcp协议
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");//连接本地的
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 58614);//申请端口号
            severSocket.Bind(iPEndPoint);//绑定端口号，像系统申请端口号和地址
            severSocket.Listen(0);//持续性处理客户端
            Socket clientSocket = severSocket.Accept();//接收一个客户端的连接

            string msgstring = "Hi ! 你好";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msgstring);
            clientSocket.Send(data);//向每个连接的客户端发送消息

            string msgstrings= "Hi ! 你好你好鳄梨好";
            byte[] datas= System.Text.Encoding.UTF8.GetBytes(msgstrings);
            clientSocket.Send(datas);//向每个连接的客户端发送消息

            clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.StartIndex, SocketFlags.None, ReceiveCallBack, clientSocket);//异步接收这是一步的任务
            //msg.Data 接受的数组，msg.StartIndex什么位置开始存储，msg.StartIndex存储的空间大小，等这个值小于0时表示这个数据包不是完整的就接着获取哪一个数据包来解析
        }

        static void ReceiveCallBack(IAsyncResult ar)
        {

            Socket clientSocket = null;
            try
            {
                clientSocket = ar.AsyncState as Socket;//接受消息的位置
                int count = clientSocket.EndReceive(ar);
                if (count == 0)
                {
                    clientSocket.Close();
                    return; 
                }
                msg.AddCount(count);
                msg.ReadMessage();//解析接收到的数据
                clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.StartIndex, SocketFlags.None, ReceiveCallBack, clientSocket);//异步接收这是一步的任务
                //string msgstring = System.Text.Encoding.UTF8.GetString(dataBuffer, 0, count);
                //Console.WriteLine("客户端接收数据：" + msgstring);
                //clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, ReceiveCallBack, clientSocket);//循环执行异步
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (clientSocket != null)
                {
                    clientSocket.Close();
                }
            }
            //clientSocket.BeginAccept(AcceptCallBack, clientSocket);
        }
        static void AcceptCallBack(IAsyncResult ar)
        {
            Socket serverSocket = ar.AsyncState as Socket;//类型是相同的能获取socket
            Socket clientSocket = serverSocket.EndAccept(ar);//接收客户端的连接

            string msg = "Hello client ! 你好 ....向每个连接到服务端的客户提供服务";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);
            clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, ReceiveCallBack, clientSocket);//异步接收这是一步的任务
            serverSocket.BeginAccept(AcceptCallBack, serverSocket);//再执行时表示接收多个客户端的请求

        }

    }
}
