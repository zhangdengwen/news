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
    public partial class news : System.Web.UI.Page
    {
        //初始化时显示数据
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater cateList = this.Master.FindControl("cateList") as Repeater;
            cateList.DataSource = CategoryManager.getCateList();
            cateList.DataBind();

            //判断新闻是否有带参数过来
            detailNews();

            //获取用户信息展示到页面中
            User userInfo = Session["userInfo"] as User;
            //判断是否已经存储了实例
            if (userInfo == null)
            {
                return;
            }
            Label nick = this.Master.FindControl("nick") as Label;
            nick.Text = userInfo.nickName;
            //只有当前用户登录了，才应该有头像出来！！
            this.userImg.ImageUrl = userInfo.userAvatar;
        }

        //新闻详情的代码
        private void detailNews()
        {
            //if (!Request.QueryString.HasKeys())
            //{
            //    Response.Redirect("~/index.aspx");
            //}
            //通过新闻id来获取新闻来显示
            int id = int.Parse(Request.QueryString["id"]);
            News detail = NewsManager.getNewsDetail(id);
            //如果新闻不存在，就跳转到首页
            if (detail == null)
            {
                Response.Redirect("~/index.aspx");
            }
            this.title.Text = detail.title;
            this.titleMini.Text = detail.createtime.ToString();
            this.content.Text = detail.content;

            //新闻详情页的标题头部
            Page.Header.Title = detail.title;

            //获取新闻的右侧发布者的信息
            getNewsUserInfo(detail.user_id);

            //获取新闻评论列表回来展示
            getNewsCommentList(detail.id);
            
        }

        private void getNewsCommentList(int id)
        {
            List<Comment> comList = CommentManager.getCommentList(id);
            this.commentList.DataSource = comList;
            this.commentNum.Text = comList.Count.ToString();
            this.commentList.DataBind();
        }

        private void getNewsUserInfo(int user_id)
        {
            //新闻列表获取
            List<News> newsList = NewsManager.getUserSendNewsList(user_id);
            //发布者的信息获取
            User userInfo = UserManager.getSendUserInfo(user_id);

            //赋值过去
            if (newsList == null)
            {
                return;
            }
            this.sendList.DataSource = newsList;
            this.sendList.DataBind();

            if (userInfo == null)
            {
                return;
            }
            this.userImage.ImageUrl = userInfo.userAvatar;
            this.nickName.Text = this.usersName.Text = userInfo.nickName;
        }

        //点击发表评论
        protected void sendComment(object sender, EventArgs e)
        {
            //1、判断用户是否登录了，如果没有登录，不允许评论！
            User userInfo = Session["userInfo"] as User;
            if (userInfo == null)
            {
                Response.Write("<script>alert('请先登录！');</script>");
                return;
            }
            //获取评论框中的内容
            string comment = this.commentSay.Text;
            if (comment == string.Empty)
            {
                Response.Write("<script>alert('请输入评论内容！');</script>");
                return;
            }
            //拼一个Comment类信息来保存
            Comment commentInfo = new Comment();
            commentInfo.comment = comment;
            commentInfo.user_id = userInfo.id;
            commentInfo.createtime = DateTime.Now;
            commentInfo.state = 1;
            commentInfo.news_id = int.Parse(Request.QueryString["id"]);

            //执行保存操作
            if (CommentManager.saveUserComment(commentInfo))
            {
                Response.Write("<script>alert('评论成功！');</script>");
                Response.Redirect("news.aspx?id="+ int.Parse(Request.QueryString["id"]));
            }
            else
            {
                Response.Write("<script>alert('评论失败！');</script>");
            }
        }
    }
}