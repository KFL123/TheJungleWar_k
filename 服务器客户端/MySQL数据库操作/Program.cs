using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace MySQL数据库操作
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Database=test007;Data source=127.0.0.1;port=3306;User Id=root;Password=root";//test007 表名，127.0.0.1 IP地址  3306端口号  后面就是用户和密码了
            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();//打开连接我们已经和数据库进行连接，然后打开数据库

            #region 查询
            //MySqlCommand cmd_form = new MySqlCommand("select * form user", conn);//MySqlCommand 就是命令语句创建一条新的命令语句
            //MySqlDataReader reader = cmd_form.ExecuteReader();//查询  返回的是数据流
            //while (reader.Read())
            //{//判断是否有行，有表示有数据
            //    reader.Read();//开始读取一条信息
            //    string username = reader.GetString("username");//获取这一列
            //    string rasswoed = reader.GetString("password");
            //    Console.WriteLine(username + ":" + rasswoed);

            //}
           // reader.Close();//数据传输流关闭
            #endregion
            #region 插入
            //string username_insert = "cwer", password = "lcker";
            //// MySqlCommand cmd = new MySqlCommand("insert into user set username='"+ username+"',password='"+password+"'",conn);
            //MySqlCommand cmd = new MySqlCommand("insert into user set username=@un，password=@pwd",conn);
            //username_insert.Parameters.AddWithValue("un",username);//un he username 都可以。
            //username_insert.Parameters.AddWithValue("password",password);//password 和pwd也是可以的。

            //cmd.ExecuteNonQuery();
            #endregion
            #region 删除
            //MySqlCommand cmd_delete = new MySqlCommand("delete form user where id = @id",conn);
            //cmd_delete.Parameters.AddWithValue("id",18);//删除id为18的这个参数值
            //cmd_delete.ExecuteNonQuery();
            #endregion

            #region 更新
            //执行更新某个id 的密码
            //MySqlCommand cmd_update = new MySqlCommand("update user set password = @pwd where id = 11",conn);
            //cmd_update.Parameters.AddWithValue("pwd","sikiedu.com");//修改id为18的密码改为 sikiedu.com
            //cmd_update.ExecuteNonQuery();//查找是否存在
            #endregion
            conn.Close();//关闭数据库的连接

            Console.ReadKey();

        }
    }
}
