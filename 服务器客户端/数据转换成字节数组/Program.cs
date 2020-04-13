using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 数据转换成字节数组
{
    class Program
    {
        static void Main(string[] args)
        {

            GetByte_s(5806);
        }
        static void GetByte_s(int str)
        {
            byte[] data = BitConverter.GetBytes(str);
            foreach (var item in data)
            {
                Console.Write(item+":");
            }
            Console.ReadKey();//必须添加，不然窗口回一闪而过。

        }
    }
}
