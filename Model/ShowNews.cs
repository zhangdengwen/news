using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class ShowNews
    {
        //新闻的id
        public int id { get; set; }
        //新闻标题
        public string title { get; set; }
        //新闻创建时间
        public DateTime createtime { get; set; }
        //新闻图片
        public string img { get; set; }
        //用户昵称
        public string nickName { get; set; }
        //用户头像
        public string userAvatar { get; set; }
        //分类名称
        public string catename { get; set; }
    }
}
