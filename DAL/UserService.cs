using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 用于对数据库的表执行增删改查的层DAL层
    /// UserService类是对数据库的User表执行增删改查操作
    /// </summary>
    public class UserService
    {
        //求用户总数
        public static int getUserCount(int role, string key)
        {
            string sql = $"select count(*) as sum from [user] where role=0 and username like '%{key}%' ";
            SqlDataReader dr = DBHelper.getData(sql);
            int result = 0;
            while (dr.Read())
            {
                result = int.Parse(dr["sum"].ToString());
            }
            //需要关闭链接
            dr.Close();
            return result;
        }
        //获取用户列表
        public static DataTable getuserList(int pageNum, int pageSize, string key,int role)
        {
            int offsetNum = (pageNum - 1) * pageSize; //页码偏移量，从多少页开始取后面的数据回来的意思！！
            string sql = $"select * from [user] where role={role} and username like '%{key}%' order by id desc offset {offsetNum} rows fetch next {pageSize} rows only ";
            return DBHelper.getDataTable(sql);
        }

        //增加数据：添加用户到用户表User表中
        public static bool addUser(User userInfo)
        {
            //执行插入sql
            string sql = string.Format("insert into [user](username,password,userAvatar,nickName,introduce,state,createtime,role) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", userInfo.username,userInfo.password,userInfo.userAvatar,userInfo.nickName,userInfo.introduce,userInfo.state,userInfo.createtime,userInfo.role);
            //执行插入sql
            return  DBHelper.updateData(sql);
            //返回结果
        }
        //删除数据：删除用户表中的用户信息
        public static bool deleteUser(int id)
        {
            //删除sql
            string sql = string.Format("delete from [user] where id='{0}'", id);
            //执行删除sql
            return DBHelper.updateData(sql);
            //返回结果
        }
        //修改数据：修改用户表中的用户信息
        public static bool updateUser(User userInfo)
        {
            //执行插入sql
            string sql = string.Format("update [user] set username='{0}',password='{1}',userAvatar='{2}',nickName='{3}',introduce='{4}',state='{5}',createtime='{6}' where id='{7}'", userInfo.username, userInfo.password, userInfo.userAvatar, userInfo.nickName, userInfo.introduce, userInfo.state, userInfo.createtime,userInfo.id);
            //执行插入sql
            return DBHelper.updateData(sql);
            //返回结果
        }

        //用户列表的修改方法
        public static bool updateUserInfo(User userInfo)
        {
            //执行插入sql
            string sql = string.Format("update [user] set password='{0}',state='{1}' where id='{2}'", userInfo.password, userInfo.state, userInfo.id);
            //执行插入sql
            return DBHelper.updateData(sql);
            //返回结果
        }

        //新增一个 ： 修改密码的方法
        public static bool updateUserPassword(User userInfo)
        {
            //执行插入sql
            string sql = string.Format("update [user] set password='{0}',nickName='{1}' where id='{2}'",  userInfo.password,  userInfo.nickName,  userInfo.id);
            //执行插入sql
            return DBHelper.updateData(sql);
            //返回结果
        }

        //查询数据：查询用户表中的用户信息
        public static User getUserInfo(string userName)
        {
            //查询sql
            string sql = string.Format("select * from [user] where username='{0}'", userName);
            //执行返回结果
            SqlDataReader dr = DBHelper.getData(sql);
            //存到我们的数据模型类中
            User userInfo = null;
            if(dr.Read())
            {
                userInfo = new User();
                userInfo.id = dr.GetInt32(0);
                userInfo.username = dr.GetString(1);
                userInfo.password = dr.GetString(2);
                userInfo.userAvatar = dr.GetString(3);
                userInfo.nickName = dr.GetString(4);
                userInfo.introduce = dr.GetString(5);
                userInfo.state = int.Parse(dr["state"].ToString());
                userInfo.role = int.Parse(dr["role"].ToString()); //需要额外新增该角色字段返回
                userInfo.createtime = dr.GetDateTime(7);
            }
            //关闭我们的阅读
            dr.Close();
            //返回用户信息
            return userInfo;
        }

        //获取用户的信息详情
        public static User getNewsUserInfo(int id)
        {
            //查询sql
            string sql = string.Format("select nickName,userAvatar from [user] where id='{0}'", id);
            //执行返回结果
            SqlDataReader dr = DBHelper.getData(sql);
            //存到我们的数据模型类中
            User userInfo = null;
            if (dr.Read())
            {
                userInfo = new User();
                userInfo.nickName = dr["nickName"].ToString();
                userInfo.userAvatar = dr["userAvatar"].ToString();
            }
            //关闭我们的阅读
            dr.Close();
            //返回用户信息
            return userInfo;
        }
    }
}
