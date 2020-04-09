using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Net;
using System.Net.Sockets;

namespace TCP客户端_0_0_1v
{

    class Program
    {
        static void Main(string[] args)
        {
            Socket clientsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientsocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 58614));

            byte[] data = new byte[1024];
            int count = clientsocket.Receive(data);
            string msg = System.Text.Encoding.UTF8.GetString(data, 0, count);
            Console.Write(msg);

            while (true)
            {
                string s = Console.ReadLine();
                Console.Write(s);
                if (s == "c")
                {
                    clientsocket.Close();//如果输入c退出
                }
                clientsocket.Send(System.Text.Encoding.UTF8.GetBytes(s));
            }
#pragma warning disable CS0162 // 检测到无法访问的代码
            Console.ReadKey();//接收
#pragma warning restore CS0162 // 检测到无法访问的代码
            clientsocket.Close();//关闭

        }
    }
}
