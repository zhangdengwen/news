using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace news.Back
{
    public partial class CommentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            string table = "Comment";
            string condition = $" where comment like '%{key}%' ";
            string sql = " select c.id,comment,userAvatar,username,nickName,title from comment c left join [user] u on c.user_id = u.id left join news n on c.news_id = n.id "+condition;
            this.userList.DataSource = CommonManager.CommonGetSqlList(page, 10, sql);
            //先求解出当前的总条数 =》 通过总条数求解出可以分多少页
            int sum = CommonManager.getCount(table,condition);
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