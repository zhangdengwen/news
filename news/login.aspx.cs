using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace news
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //验证码随机生成
            if(!IsPostBack)
            {
                checkVerify();
            }
        }

        //验证码生成
        private void checkVerify()
        {
            Random ran = new Random();
            this.verify__code.Text = ran.Next(1000, 9999).ToString();
        }

        //点击事件，实现注册功能
        protected void register__btn_Click(object sender, EventArgs e)
        {
            //1、获取数据
            string userName = this.newUser.Text;
            string password = this.newPass.Text;
            // 2、校验数据

            // 3、保存数据
            if(UserManager.addUser(userName,password))
            {
                Response.Write("<script>alert('注册用户成功！');</script>");
            }
            else
            {
                Response.Write("<script>alert('用户注册失败！');</script>");
            }

        }

        //点击登录
        protected void login__btn_Click(object sender, EventArgs e)
        {
            //1、获取表单数据
            string userName = this.user.Text;
            string password = this.password.Text;
            string verify = this.verify.Text;

            //2、校验表单数据
            //(1)校验用户名不能为空
            if(userName.ToString().Trim() == string.Empty)
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
            //(3)校验验证码不能为空
            if (verify.ToString().Trim() == string.Empty)
            {
                Response.Write("<script>alert('验证码不能为空！');</script>");
                return;
            }
            //(4)校验验证码是否正确
            if (this.verify__code.Text != verify.ToString())
            {
                //验证码不正确时，刷新验证码
                checkVerify();
                Response.Write("<script>alert('验证码不正确！');</script>");
                return;
            }
            //3、判断用户名密码是否正确，再执行跳转
            User userInfo = UserManager.checkUser(userName,password);
            if(userInfo != null)
            {
                if (userInfo.role != 0)
                {
                    Response.Write("<script>alert('不存在该用户！');</script>");
                }
                else if (userInfo.state != 1)
                {
                    Response.Write("<script>alert('该用户已停用！');</script>");
                }
                else
                {
                    Response.Write("<script>alert('登录成功！');</script>");
                    //用SESSION记住用户信息，可以在的别页面去使用这个信息
                    Session["userInfo"] = userInfo;
                    //进行跳转到某个页面
                    Response.Redirect("~/user.aspx");
                }
            }  
            else
            {
                Response.Write("<script>alert('用户名或密码错误！');</script>");
            }
        }
    }
}