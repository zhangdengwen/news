using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommentService
    {
        //保存评论操作
        public static bool saveComment(Comment commentInfo)
        {
            //1、保存sql
            string sql = string.Format("insert into comment(comment,user_id,createtime,state,news_id) values('{0}','{1}','{2}','{3}','{4}')",commentInfo.comment,commentInfo.user_id,commentInfo.createtime,commentInfo.state,commentInfo.news_id);
            //2、执行保存sql操作
            return DBHelper.updateData(sql);
        }
        //获取新闻详情中的评论列表
        public static List<Comment> getCommentList(int newsId)
        {
            //查询sql
            string sql = string.Format("select c.*,u.nickName,u.userAvatar from comment c left join [user] u on c.user_id = u.id where c.news_id='{0}' and c.state=1 ",newsId);
            //执行返回结果
            SqlDataReader dr = DBHelper.getData(sql);
            //存到我们的数据模型类中
            Comment commentInfo = null;
            //泛型列表存储一下分类列表返回
            List<Comment> commentList = new List<Comment>();
            while (dr.Read())
            {
                commentInfo = new Comment();
                commentInfo.id = dr.GetInt32(0);
                commentInfo.comment = dr["comment"].ToString();
                commentInfo.user_id = int.Parse(dr["user_id"].ToString());
                commentInfo.state = int.Parse(dr["state"].ToString());
                commentInfo.news_id = int.Parse(dr["news_id"].ToString());
                commentInfo.createtime = DateTime.Parse(dr["createtime"].ToString());
                commentInfo.nickName = dr["nickName"].ToString();
                commentInfo.userAvatar = dr["userAvatar"].ToString();
                //存到泛型中
                commentList.Add(commentInfo);
            }
            //关闭我们的读取连接
            dr.Close();
            //返回用户信息
            return commentList;
        }
    }
}
