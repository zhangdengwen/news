using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    //CommonManager中转层，主要是用于操作相同功能时的转折层
    public class CommonManager
    {
        //公共的求和方法
        public static int getCount(string table,string condition)
        {
            return CommonService.getCount(table, condition);
        }

        // 传sql执行的方法查询列表
        public static DataTable CommonGetSqlList(int page, int pageSize, string sql)
        {
            return CommonService.CommonGetSqlList(page, pageSize,sql);
        }

        //公共的列表展示方法
        public static DataTable CommonGetList(int page, int pageSize, string table, string filed, string condition)
        {
            return CommonService.CommonGetList(page,pageSize, table, filed,condition);
        }

        //执行公共的删除中转
        // 这里的参数说明： id为需要删除对应的信息ID，type指定的为表名
        public static bool CommonDelete(int id, string type)
        {
            //需要对type = "user"的表进行判断，是否已经存在文章，存在文章不给删除
            if(type == "user")
            {
                if(NewsService.CheckNewsCount(id) > 0)
                {
                    return false;
                } 
            }
            //如果上面判断文章不存在，则正常执行删除
            return CommonService.CommonDelete(id, type);
        }
    }
}
