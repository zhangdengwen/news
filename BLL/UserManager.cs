using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 业务逻辑层，需要实现表现层中的功能逻辑
    /// UserManager类主要对用户表的逻辑功能实现
    /// </summary>
    public class UserManager
    {
        //获取总条数
        public static int getUserCount(int role,string key)
        {
            return UserService.getUserCount(role,key);
        }

        //用户列表管理的修改信息
        public static bool updateUserInfo(User user)
        {
            return UserService.updateUserInfo(user);
        }
        //获取用户列表返回
        public static DataTable getUserList(int pageNum, int pageSize, string key,int role=0)
        {
            return UserService.getuserList(pageNum,pageSize, key, role);
        }

        //实现管理员模块的新增
        public static bool addAdminUser(User userInfo)
        {
            //执行用户注册时，先判断用户名是否存在了
            User Info = UserService.getUserInfo(userInfo.username);
            //如果查找的用户信息不为空，那么说明用户名已存在
            if (Info != null)
            {
                return false;
            }
            return UserService.addUser(userInfo);
        }

        //注册用户功能实现
        public static bool addUser(string userName, string password)
        {
            //执行用户注册时，先判断用户名是否存在了
            User Info = UserService.getUserInfo(userName);
            //如果查找的用户信息不为空，那么说明用户名已存在
            if (Info != null)
            {
                return false;
            }
            //拼凑一个用户模型给到数据访问层
            User userInfo = new User();
            userInfo.username = userName;
            userInfo.password = password;
            userInfo.userAvatar = "~/image/headp.png";
            userInfo.nickName = "今日新闻用户";
            userInfo.state = 1; //默认是合法用户
            userInfo.createtime = DateTime.Now;
            userInfo.introduce = "";
            userInfo.role = 0; //默认普通用户
            //执行数据访问层，保存用户信息
            return UserService.addUser(userInfo);
        }

        //登录判断
        public static User checkUser(string userName, string password)
        {
            //执行用户注册时，先判断用户名是否存在了
            User Info = UserService.getUserInfo(userName);
            //如果查找的用户信息不为空，那么说明用户名已存在

            //如果用户信息存在，密码是否正确校验
            if(Info != null && Info.password != password)
            {
                return null;
            }

            return Info;
        }

        //用户信息修改
        public static bool updateUser(User userInfo)
        {
            return UserService.updateUser(userInfo);
        }

        //修改密码操作
        public static bool updateUserPassword(User userInfo)
        {
            return UserService.updateUserPassword(userInfo);
        }

        //获取新闻详情发布者的详情信息
        public static User getSendUserInfo(int user_id)
        {
            return UserService.getNewsUserInfo(user_id);
        }
    }
}
