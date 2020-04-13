using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP客户端_0_0_1v
{
    class Message
    {
        /// <summary>
        /// 转换字符串为表头
        /// </summary>
        /// <param name="data"></param>
        public static byte[] GitBytes(string data)
        {
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);//传入一个字段
            int dataLength =dataBytes.Length;//获取字段的长度
            byte[] lengthBytes = BitConverter.GetBytes(dataLength);//字段的长度转成byte[] 4位的byte
            byte[] newBytes = lengthBytes.Concat(dataBytes).ToArray();//两个数组组成一个新的数组     然后把长度的byte放在前面bata的byte 放在后面 得出一个数组，前四位是长度
            return newBytes;
        }

    }
}
