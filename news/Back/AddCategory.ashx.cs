using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace news.Back
{
    /// <summary>
    /// AddCategory1 的摘要说明
    /// </summary>
    public class AddCategory1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string catename = context.Request["catename"].ToString();
            //2、实现分类的功能
            Category cate = new Category()
            {
                id = 0,
                catename = catename
            };
            //这里需要判断是否存在 id字段来区分是添加分类，还是修改分类
            if (context.Request["id"] != null)
            {
                //说明这里是编辑操作
                cate.id = int.Parse(context.Request["id"].ToString());
            }
            
            if (CategoryManager.addCategory(cate))
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