﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DBHelper
    {
        //数据库连接配置字符串
        public static string connStr = "Data Source=ZDW;Initial Catalog=hotNew;Integrated Security=True";
        //连接数据库对象
        public static SqlConnection conn = null;

        //连接数据库方法
        public static void Open()
        {
            //先判断当前是否已经创建连接对象
            if(conn == null)
            {
                conn = new SqlConnection(connStr);
            }
            //判断当前连接状态是否是断开的，如果断开需要连接
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        //对数据库执行增删改方法
        public static bool updateData(string sql)
        {
            try
            {
                //1、先开启数据库
                Open();
                //2、数据库的方法操作
                SqlCommand cmd = new SqlCommand(sql, conn);
                //3、执行sql方法
                int result = cmd.ExecuteNonQuery();
                //4、返回执行的结果
                return result > 0;
            }
            catch(Exception)
            {
                //防止弹出异常，停止运行程序
                return false;
            }
            
        }
        //对数据库执行查询方法
        public static SqlDataReader getData(string sql)
        {
            try { 
                //1、先开启数据库
                Open();
                //2、数据库操作sql方法
                SqlCommand cmd = new SqlCommand(sql,conn);
                //3、执行查询
                SqlDataReader dr = cmd.ExecuteReader();
                //4、返回结果
                return dr;
            }
            catch(Exception)
            {
                //防止弹出异常，停止运行程序
                return null;
            }
}

        //获取表格形式的数据返回
        public static DataTable getDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try { 
                //1、先开启数据库
                Open();
                //2、数据库操作sql方法
                SqlDataAdapter sa = new SqlDataAdapter(sql,conn);
                //3、执行查询
                sa.Fill(dt);
                //4、返回结果
                return dt;
            }
            catch(Exception)
            {
                //防止弹出异常，停止运行程序
                return dt;
            }
        }
    }
}
