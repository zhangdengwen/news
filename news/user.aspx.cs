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
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取用户信息展示到页面中
            User userInfo = Session["userInfo"] as User;
            //判断是否已经存储了实例
            if(userInfo == null)
            {
                return;
            }
            this.userImg.ImageUrl = userInfo.userAvatar;
            this.nick.Text = this.nickName.Text = userInfo.nickName;

            //从业务逻辑层中获取分类列表回来
            this.cateList.DataSource = CategoryManager.getCateList();
            this.cateList.DataBind();

            //从业务逻辑层中获取新闻列表回来
            this.newsList.DataSource = NewsManager.getNewsList(userInfo.id);
            this.newsList.DataBind();
        }
    }
}