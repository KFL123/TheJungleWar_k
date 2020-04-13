using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP服务器_0_0_1v
{
    class Message
    {

        private byte[] data = new byte[1024];//定义一个接受的byte的大小
        private int startIndex = 0;//什么位置来时存数据
        public void AddCount(int count)
        {
            startIndex += count;
        }
        public byte[] Data
        {//data接受客户端的数据存储这个data
            get { return data; }
        }
        public int StartIndex
        {//开始什么位置存储
            get { return startIndex; }
        }
        public int RemainSize
        {//
            get { return data.Length - startIndex; }
        }

        public void ReadMessage()
        {
            while(true)
            {
                if (startIndex <= 4) return;
                int count = BitConverter.ToInt32(data,0);//解析获取的数据  BitConverter.ToInt32只能获取四个字节，所以不管怎么获取这个数组得到的都是这些数据值
                if ((startIndex-4)>=count)
                {//数据长度大于4字节
                    Console.WriteLine(startIndex);
                    Console.WriteLine(count);
                    string s = System.Text.Encoding.UTF8.GetString(data,4,count);
                    Console.Write("解析出数据：" + s);
                    Array.Copy(data,count+4,data,0,startIndex-4-count);//数组替换data 数组位置count+4开始，表示这条数数据时读取过的，我们要把 这条数据清除掉，替换的数据还是data 替换到的位置时0，替换的位置从那个长度开始 中长度-4-count，得到没有解析过的数据，而且替换到原数组中去。
                    startIndex -= (count+4);
                }
                else
                {
                    break;
                }
                
            }


        }

    }
}
