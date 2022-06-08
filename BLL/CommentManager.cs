using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommentManager
    {
        //执行保存评论操作
        public static bool saveUserComment(Comment cInfo)
        {
            return CommentService.saveComment(cInfo);
        }

        //获取保存列表信息回来
        public static List<Comment> getCommentList(int newsId)
        {
            return CommentService.getCommentList(newsId);
        }
    }
}
