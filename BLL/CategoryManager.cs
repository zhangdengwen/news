using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryManager
    {
        //添加分类方法
        public static bool addCategory(Category cate)
        {
            //区分是编辑还是添加
            if(cate.id != 0)
            {
                return CategoryService.updateCategory(cate);
            }
            return CategoryService.addCategory(cate);
        }
        //获取列表数据回来
        public static List<Category> getCateList()
        {
            return CategoryService.getCategoryList();
        }
    }
}
