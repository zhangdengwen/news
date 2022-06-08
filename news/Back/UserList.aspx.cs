using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace news.Back
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果用户未登录，不能够到后台过来
            if (Session["AdminInfo"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                //获取用户列表回来展示
                getList();
            }
            
        }
        public static decimal pageNumber = 1;
        private void getList(string key="")
        {
            int page = 1;
            if (Request["page"] != null)
            {
                page = int.Parse(Request["page"].ToString());
            }
            this.userList.DataSource = UserManager.getUserList(page, 10,key);
            //先求解出当前的总条数 =》 通过总条数求解出可以分多少页
            int sum = UserManager.getUserCount(0,key);
            // 分多少页
            pageNumber = Math.Ceiling(sum / 10M);

            DataBind();
        }

        //实现按钮的点击事件
        protected void Button1_Click(object sender, EventArgs e)
        {
            string key = this.username.Text;
            getList(key);
        }
    }
}