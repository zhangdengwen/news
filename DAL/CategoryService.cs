using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
    public class CategoryService
    {
        //修改分类
        public static bool updateCategory(Category cate)
        {
            string sql = $"update Category set catename='{cate.catename}' where id='{cate.id}'";
            return DBHelper.updateData(sql);
        }
        //执行添加方法
        public static bool addCategory(Category cate)
        {
            string sql = $"insert into category(catename,createtime) values('{cate.catename}','{DateTime.Now}')";
            return DBHelper.updateData(sql);
        }
        //获取分类列表回来
        public static List<Category> getCategoryList()
        {
            //查询sql
            string sql = string.Format("select * from category");
            //执行返回结果
            SqlDataReader dr = DBHelper.getData(sql);
            //存到我们的数据模型类中
            Category cateInfo = null;
            //泛型列表存储一下分类列表返回
            List<Category> cateList = new List<Category>();
            while(dr.Read())
            {
                cateInfo = new Category();
                cateInfo.id = dr.GetInt32(0);
                cateInfo.catename = dr.GetString(1);
                cateInfo.createtime = dr.GetDateTime(2);
                //把获取到的分类存到泛型列表中
                cateList.Add(cateInfo);
            }
            //关闭我们的读取连接
            dr.Close();
            //返回用户信息
            return cateList;
        }
    }
}
