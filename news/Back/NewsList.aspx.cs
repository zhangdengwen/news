using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace news.Back
{
    public partial class NewsList : System.Web.UI.Page
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
        private void getList(string key = "")
        {
            int page = 1;
            if (Request["page"] != null)
            {
                page = int.Parse(Request["page"].ToString());
            }
            string table = "News";
            string condition = $" where title like '%{key}%' ";
            string sql = " select n.*,u.nickName,c.catename from news n left join [user] u on n.user_id = u.id left join category c on n.category_id = c.id " + condition;
            this.userList.DataSource = CommonManager.CommonGetSqlList(page, 10, sql);
            //先求解出当前的总条数 =》 通过总条数求解出可以分多少页
            int sum = CommonManager.getCount(table, condition);
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