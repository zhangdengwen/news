using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace news
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //【注意，因为如果没有登录用户，就导致没有执行到这个代码】从业务逻辑层中获取分类列表回来
            this.navList.DataSource = this.cateList.DataSource = CategoryManager.getCateList();
            this.cateList.DataBind();
            this.navList.DataBind();

            //获取新闻列表回来
            getNewsList();

            //获取用户信息展示到页面中
            User userInfo = Session["userInfo"] as User;
            //判断是否已经存储了实例
            if (userInfo == null)
            {
                return;
            }
            this.nick.Text = this.nickName.Text = userInfo.nickName;
            this.userImg.ImageUrl = userInfo.userAvatar;
        }

        public static decimal pageNumber = 1;
        private void getNewsList()
        {
            //判断当前是否有id
            int id = 0;
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"]);
            }
            int page = 1;
            if (Request["page"] != null)
            {
                page = int.Parse(Request["page"].ToString());
            }
            string table = "News";
            string condition = "";
            if (id != 0)
            {
                // $""的作用类似于string.Format();
                condition = $" where category_id='{id}' and state = 1 ";
            }
            //先求解出当前的总条数 =》 通过总条数求解出可以分多少页
            int sum = CommonManager.getCount(table, condition);
            // 分多少页
            pageNumber = Math.Ceiling(sum / 10M);

            int pageSize = 10; //每页展示的数量
            this.newsList.DataSource =  NewsManager.getIndexNewsList(page, pageSize,id);
            this.newsList.DataBind();
        }
    }
}