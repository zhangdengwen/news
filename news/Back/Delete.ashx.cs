using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace news.Back
{
    /// <summary>
    /// Delete 的摘要说明
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1、获取参数
            int id = int.Parse(context.Request["id"].ToString());
            string type = context.Request["type"].ToString();

            //给它一个公共的中转层
            if (CommonManager.CommonDelete(id,type))
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