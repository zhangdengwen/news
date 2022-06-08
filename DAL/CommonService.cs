using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    //共同相关的操作服务层
    public class CommonService
    {
        //公用的分页方法求条数
        public static int getCount(string table, string condition)
        {
            string sql = $"select count(*) as sum from [{table}] "+condition;
            SqlDataReader dr = DBHelper.getData(sql);
            int result = 0;
            while (dr.Read())
            {
                result = int.Parse(dr["sum"].ToString());
            }
            //需要关闭链接
            dr.Close();
            return result;
        }

        // 传sql执行的方法查询列表
        public static DataTable CommonGetSqlList(int pageNum, int pageSize, string sql)
        {
            int offsetNum = (pageNum - 1) * pageSize; //页码偏移量，从多少页开始取后面的数据回来的意思！！
            sql += $" order by id desc offset {offsetNum} rows fetch next {pageSize} rows only ";
            return DBHelper.getDataTable(sql);
        }

        //公共查找方法
        public static DataTable CommonGetList(int pageNum, int pageSize, string table, string filed,string condition)
        {
            int offsetNum = (pageNum - 1) * pageSize; //页码偏移量，从多少页开始取后面的数据回来的意思！！
            string sql = $"select {filed} from {table} "+ condition;
            sql += $" order by id desc offset {offsetNum} rows fetch next {pageSize} rows only ";
            return DBHelper.getDataTable(sql);
        }

        //多表的共用删除方法
        public static bool CommonDelete(int id, string type)
        {
            string sql = $"delete from [{type}] where id = {id}";
            return DBHelper.updateData(sql);
        }
    }
}
