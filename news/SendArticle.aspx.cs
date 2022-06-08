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
    public partial class SendArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果用户未登录，不允许进来这里！！
            if(Session["userInfo"] == null)
            {
                Response.Redirect("login.aspx");
            }

            //需要获取分类列表回来
            this.cateList.DataSource = CategoryManager.getCateList();
            this.cateList.DataBind();
        }

        //存为草稿事件
        protected void save1_Click(object sender, EventArgs e)
        {
            //1、获取新闻发表时的数据
            string title = this.title.Text;
            int cateId = int.Parse(Request.Form["category"]);
            string content = Request.Form["content"];
            string pic = Request.Form["pic"];
            string picPath = "";

            //2、判断当前是否需要上传图片
            if (pic == "1")
            {
                //执行图片上传操作
                if (ImgUpload.HasFile)
                {
                    //获取上传的图片名称
                    string fileName = ImgUpload.FileName;
                    //判断当前文件是否是图片
                    string back = Path.GetExtension(fileName).ToLower(); //获取到的扩展名都是带点.的。例如：11.png 获取到的后缀名为：.png
                    if (back != ".png" && back != ".jpeg" && back != ".jpg" && back != ".gif")
                    {
                        Response.Write("<script>alert('您选择的不是图片！');</script>");
                        return;
                    }
                    //执行图片上传，获取路径
                    picPath = "/Upload/" + DateTime.Now.ToString("yyMMss") + "_" + fileName;
                    ImgUpload.SaveAs(Server.MapPath(picPath));
                }
                else
                {
                    Response.Write("<script>alert('请选择需要上传的图片！');</script>");
                    return;
                }
            }

            //3、组装数据，保存到数据库中
            User userInfo = Session["userInfo"] as User;
            News news = new News()
            {
                title = title,
                content = content,
                user_id = userInfo.id,
                category_id = cateId,
                state = 0, //0是草稿
                createtime = DateTime.Now,
                img = picPath
            };
            if (NewsManager.addNews(news))
            {
                Response.Write("<script>alert('保存新闻成功！');</script>");
            }
            else
            {
                Response.Write("<script>alert('保存新闻失败！');</script>");
            }
        }

        protected void save2_Click(object sender, EventArgs e)
        {
            //1、获取新闻发表时的数据
            string title = this.title.Text;
            int cateId = int.Parse(Request.Form["category"]);
            string content = Request.Form["content"];
            string pic = Request.Form["pic"];
            string picPath = "";

            //2、判断当前是否需要上传图片
            if (pic == "1")
            {
                //执行图片上传操作
                if (ImgUpload.HasFile)
                {
                    //获取上传的图片名称
                    string fileName = ImgUpload.FileName;
                    //判断当前文件是否是图片
                    string back = Path.GetExtension(fileName).ToLower(); //获取到的扩展名都是带点.的。例如：11.png 获取到的后缀名为：.png
                    if (back != ".png" && back != ".jpeg" && back != ".jpg" && back != ".gif")
                    {
                        Response.Write("<script>alert('您选择的不是图片！');</script>");
                        return;
                    }
                    //执行图片上传，获取路径
                    picPath = "/Upload/" + DateTime.Now.ToString("yyMMss") + "_" + fileName;
                    ImgUpload.SaveAs(Server.MapPath(picPath));
                }
                else
                {
                    Response.Write("<script>alert('请选择需要上传的图片！');</script>");
                    return;
                }
            }

            //3、组装数据，保存到数据库中
            User userInfo = Session["userInfo"] as User;
            News news = new News()
            {
                title = title,
                content = content,
                user_id = userInfo.id,
                category_id = cateId,
                state = 2, //这里需要改为待审核！！！
                createtime = DateTime.Now,
                img = picPath
            };
            if (NewsManager.addNews(news))
            {
                Response.Write("<script>alert('保存新闻成功！');</script>");
            }
            else
            {
                Response.Write("<script>alert('保存新闻失败！');</script>");
            }
        }
    }
}