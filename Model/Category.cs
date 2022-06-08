using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category
    {
        //分类的ID
        public int id{ get; set; }
        //分类名称
        public string catename { get; set; }
        //创建时间
        public DateTime createtime { get; set; }
    }
}
