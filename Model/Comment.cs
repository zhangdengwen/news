using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Comment
    {
        //评论id
        public int id { get; set; }
        //用户id
        public int user_id { get; set; }
        //用户名称
        public string nickName { get; set; }
        //用户头像
        public string userAvatar { get; set; }
        //评论内容
        public string comment { get; set; }
        //创建时间
        public DateTime createtime { get; set; }
        //状态
        public int state { get; set; }
        //新闻id
        public int news_id { get; set; }
    }
}
