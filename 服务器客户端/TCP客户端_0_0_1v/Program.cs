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
            int count = clientsocket.Receive(data);//先接受信息
            string msg = System.Text.Encoding.UTF8.GetString(data, 0, count);//转换接受到的信息
            Console.Write(msg);//输出获取的信息

            while (true)
            {
                string s = Console.ReadLine();
                Console.Write(s);
                if (s == "c")
                {
                    clientsocket.Close();//如果输入c退出
                }
                clientsocket.Send(Message.GitBytes(s.ToString()));//传输的就是我们输出的
            }

            Console.ReadKey();//接收
            clientsocket.Close();//关闭
            
        }
    }
}
