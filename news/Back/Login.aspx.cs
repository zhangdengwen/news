using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace news.Back
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //登录的点击事件
        protected void Button1_Click(object sender, EventArgs e)
        {
            //1、获取登录时的用户名和密码
            string userName = this.user.Text;
            string password = this.pass.Text;

            //2、检查用户名和密码是否一致
            //(1)校验用户名不能为空
            if (userName.ToString().Trim() == string.Empty)
            {
                Response.Write("<script>alert('用户名不能为空！');</script>");
                return;
            }
            //(2)校验密码不能为空
            if (password.ToString().Trim() == string.Empty)
            {
                Response.Write("<script>alert('密码不能为空！');</script>");
                return;
            }

            //3、判断用户名密码是否正确，再执行跳转
            User userInfo = UserManager.checkUser(userName, password);

            if (userInfo != null)
            {
                //（3）校验用户的身份是管理员才行
                if(userInfo.role < 1)
                {
                    Response.Write("<script>alert('身份异常！');</script>");
                }
                else if(userInfo.state != 1)
                {
                    Response.Write("<script>alert('该用户已停用！');</script>");
                }
                else
                {
                    Response.Write("<script>alert('登录成功！');</script>");
                    //用SESSION记住用户信息，可以在的别页面去使用这个信息
                    Session["AdminInfo"] = userInfo;
                    //进行跳转到某个页面
                    Response.Redirect("~/Back/Index.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误！');</script>");
            }
        }
    }
}