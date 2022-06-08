using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace news.Back
{
    /// <summary>
    /// updateNewsState 的摘要说明
    /// </summary>
    public class updateNewsState : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = int.Parse(context.Request["id"].ToString());
            int state = int.Parse(context.Request["state"].ToString());
            //2、实现注册的功能
            if (NewsManager.updateNewsState(id, state))
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