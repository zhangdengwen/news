using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace news.Back
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class AddUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = context.Request["username"].ToString();
            string nickName = context.Request["nickName"].ToString();
            string pass = context.Request["pass"].ToString();
            //2、实现注册的功能
            User userInfo = new User()
            {
                username = username,
                userAvatar = "/img/headp.png",
                state = 1, 
                createtime = DateTime.Now,
                password = pass,
                nickName = nickName,
                role = 1,
                introduce = "无"
            };
            if (UserManager.addAdminUser(userInfo))
            {
                context.Response.Write("true");
            }
            else
            {
                context.Response.Write("false");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}