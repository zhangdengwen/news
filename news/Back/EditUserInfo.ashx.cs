using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace news.Back
{
    /// <summary>
    /// EditUserInfo 的摘要说明
    /// </summary>
    public class EditUserInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //在这里处理前端的操作
            //1、获取参数
            int userId = int.Parse(context.Request["userId"].ToString());
            string nickName = context.Request["nickName"].ToString();
            string pass = context.Request["pass"].ToString();
            //2、实现修改密码的功能
            User userInfo = new User()
            {
                id = userId,
                nickName = nickName,
                password = pass
            };
            if (UserManager.updateUserPassword(userInfo))
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