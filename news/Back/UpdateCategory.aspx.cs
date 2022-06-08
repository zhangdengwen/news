using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace news.Back
{
    public partial class UpdateCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果用户未登录，不能够到后台过来
            if (Session["AdminInfo"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}