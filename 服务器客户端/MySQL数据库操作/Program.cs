using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace MySQL数据库操作
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Database=testk;Data Source=127.0.0.1;port=3306;User=root;Password=rootroot;";//test007 表名，127.0.0.1 IP地址  3306端口号  后面就是用户和密码了
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();//打开连接我们已经和数据库进行连接，然后打开数据库
                Console.WriteLine("asffasfsa");
            }
            catch (MySqlException ex)
            {

                Console.WriteLine(ex.Message+"::::");
            }
            #region 查询 
            //MySqlCommand cmd_form = new MySqlCommand("select *from testkfl where idtestkfl", conn);//MySqlCommand 就是命令语句创建一条新的命令语句
            //MySqlDataReader reader = cmd_form.ExecuteReader();//查询  返回的是数据流
            //while (reader.Read())
            //{//判断是否有行，有表示有数据
            //    reader.Read();//开始读取一条信息
            //    string username = reader.GetString("usename");//获取这一列
            //    string rasswoed = reader.GetString("password");
            //    Console.WriteLine(username + ":" + rasswoed);
            //}
            //reader.Close();//数据传输流关闭
            #endregion
            #region 插入
            //string username_insert = "cwer", password = "lcker";
            //// mysqlcommand cmd = new mysqlcommand("insert into user set usename='"+ username+"',password='"+password+"'",conn);
            //MySqlCommand cmd = new MySqlCommand("insert into testkfl set usename=@usename, password =@password", conn);
            //cmd.Parameters.AddWithValue("usename", username_insert);//un he username 都可以。
            //cmd.Parameters.AddWithValue("password", password);//password 和pwd也是可以的。
            //cmd.ExecuteNonQuery();
            #endregion
            #region 删除
            //MySqlCommand cmd_delete = new MySqlCommand("delete from testkfl where idtestkfl = @idtestkfl", conn);
            //cmd_delete.Parameters.AddWithValue("idtestkfl", 2);//删除id为18的这个参数值
            //cmd_delete.ExecuteNonQuery();
            #endregion

            #region 更新
            //执行更新某个id 的密码
            //MySqlCommand cmd_update = new MySqlCommand("update testkfl set password = @password where idtestkfl = 1", conn);
            //cmd_update.Parameters.AddWithValue("password", "sikiedu.com");//修改id为18的密码改为 sikiedu.com
            //cmd_update.ExecuteNonQuery();//查找是否存在
            #endregion
            conn.Close();//关闭数据库的连接

            Console.ReadKey();

        }
    }
}
