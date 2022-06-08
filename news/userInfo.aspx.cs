using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace news
{
    public partial class userInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetUserInfoData();
            }
        }

        private void GetUserInfoData()
        {
            //获取用户信息展示到页面中
            User userInfo = Session["userInfo"] as User;
            //判断是否已经存储了实例
            if (userInfo == null)
            {
                return;
            }
            Image userImg = this.Master.FindControl("userImg") as Image;
            imgBox.ImageUrl = userImg.ImageUrl = userInfo.userAvatar;
            Label nick = this.Master.FindControl("nick") as Label;
            Label nickName = this.Master.FindControl("nickName") as Label;
            nickNames.Text = nick.Text = nickName.Text = userInfo.nickName;
            //描述内容
            introduce.Text = userInfo.introduce;


            //从业务逻辑层中获取分类列表回来
            Repeater cateList = this.Master.FindControl("cateList") as Repeater;
            cateList.DataSource = CategoryManager.getCateList();
            cateList.DataBind();
        }

        //修改资料操作
        protected void btn_Click(object sender, EventArgs e)
        {
            User userInfo = Session["userInfo"] as User;
            //1、头像修改
            if (FileUpload.HasFile)
            {
                //2、获取上传的文件
                string fileName = FileUpload.FileName;

                //3、判断文件的后缀是否是图片
                string back = Path.GetExtension(fileName); //它获取的后缀名是带点（.jpg）
                if(back != ".jpg" && back != ".png" && back != ".jpeg" && back != ".gif")
                {
                    this.notice.Text = "上传的不是图片！";
                    return;
                }

                //4、上传文件保存
                string newFile = "~/image/" + DateTime.Now.ToString("yyMMmmss")+back;
                // Server.MapPath方法作用是：把虚拟路径转换成物理路径，这样才能保存文件成功！！
                FileUpload.SaveAs(Server.MapPath(newFile));

                //更新用户的头像
                userInfo.userAvatar = newFile;
            }
            //2、昵称修改
            userInfo.nickName = this.nickNames.Text;

            //3、介绍修改
            userInfo.introduce = this.introduce.Text;

            //4、执行修改用户操作
            if(UserManager.updateUser(userInfo))
            {
                //更新SESSION数据
                Session["userInfo"] = userInfo;
                //重新刷新数据展示
                GetUserInfoData();
                Response.Write("<script>alert('修改用户信息成功！');</script>");
            }
            else
            {
                Response.Write("<script>alert('修改用户信息失败！');</script>");
            }
        }
    }
}