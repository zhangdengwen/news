using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace news.Back
{
    /// <summary>
    /// EditUserPassword 的摘要说明
    /// </summary>
    public class EditUserPassword : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int userId = int.Parse(context.Request["userId"].ToString());
            int state = int.Parse(context.Request["state"].ToString());
            string pass = context.Request["pass"].ToString();
            //2、实现修改密码的功能
            User userInfo = new User()
            {
                id = userId,
                state = state,
                password = pass
            };
            if (UserManager.updateUserInfo(userInfo))
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