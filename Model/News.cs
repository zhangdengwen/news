using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class News
    {
        //id字段
        public int id { get; set; }
        //新闻标题
        public string title { get; set; }
        //新闻内容
        public string content { get; set; }
        //用户id
        public int user_id { get; set; }
        //分类id
        public int category_id { get; set; }
        //状态
        public int state { get; set; }
        //创建时间
        public DateTime createtime { get; set; }
        //新闻封面图
        public string img { get; set; }

        public User user { get; set; }
        public Category category { get; set; }
    }
}
