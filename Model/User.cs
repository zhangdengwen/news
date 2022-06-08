using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class User
    {
        //用户id
        public int id { get; set; }
        //用户名
        public string username { get; set; }
        //密码
        public string password { get; set; }
        //昵称
        public string nickName { get; set; }
        //头像
        public string userAvatar { get; set; }
        //状态
        public int state { get; set; }
        //介绍
        public string introduce { get; set; }
        //创建时间
        public DateTime createtime { get; set; }

        //用户权限
        public int role { get; set; }
    }
}
