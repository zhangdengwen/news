using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    /// <summary>
    /// 新闻表的增删改查 数据访问层操作类文件
    /// </summary>
    public class NewsService
    {
        //审核通过
        public static bool updateNewsState(int id,int state)
        {
            string sql = $"update News set state='{state}' where id = {id}";
            return DBHelper.updateData(sql);
        }
        //判断用户是否存在文章需要删除
        public static int CheckNewsCount(int id)
        {
            string sql = $"select * from News where user_id = {id}";
            return DBHelper.getDataTable(sql).Rows.Count; //返回行数判断，是否存在文章了
        }
        ///查询新闻列表回来
        //需要传用户id来匹配用户的新闻列表回去
        public static List<News> getNewsList(int userId,bool boolType=true)
        {
            string sql = string.Format("select * from News where user_id='{0}'", userId);
            //查询sql
            if(!boolType)
            {
                sql = string.Format("select top 5 * from News where user_id='{0}' and state=1 order by createtime desc", userId);
            }
            
            //执行返回结果
            SqlDataReader dr = DBHelper.getData(sql);
            //存到我们的数据模型类中
            News newsInfo = null;
            //泛型列表存储一下分类列表返回
            List<News> newsList = new List<News>();
            while (dr.Read())
            {
                newsInfo = new News();
                newsInfo.id = dr.GetInt32(0);
                newsInfo.title = dr.GetString(1);
                newsInfo.content = dr.GetString(2);
                newsInfo.user_id = dr.GetInt32(3);
                newsInfo.category_id = dr.GetInt32(4);
                newsInfo.state = dr.GetInt32(5);
                newsInfo.createtime = dr.GetDateTime(6);
                newsInfo.img = dr.GetString(7);
                //把获取到的分类存到泛型列表中
                newsList.Add(newsInfo);
            }
            //关闭我们的读取连接
            dr.Close();
            //返回用户信息
            return newsList;
        }

        //首页的新闻列表获取
        public static List<ShowNews> getIndexNewsList(int pageNum,int pageSize,int id,string keyword="")
        {
            //拼个条件筛选
            string condition = "";
            if(id != 0)
            {
                // $""的作用类似于string.Format();
                condition = $" category_id='{id}' and ";
            }
            if(keyword != "")
            {
                condition += $" title like '%{keyword}%' and ";
            }
            // 分页功能： 需要知道两个值，【一个是页码数，每页展示的数量】
            int offsetNum = (pageNum - 1 ) * pageSize; //页码偏移量，从多少页开始取后面的数据回来的意思！！
            string sql = string.Format("select n.id,n.title,n.createtime,n.img,u.userAvatar,u.nickName,c.catename from News n left join [user] u on n.user_id = u.id left join category c on n.category_id = c.id where "+ condition + " n.state=1 order by createtime desc offset {0} rows fetch next {1} rows only ",offsetNum,pageSize );
            
            //执行返回结果
            SqlDataReader dr = DBHelper.getData(sql);
            //存到我们的数据模型类中
            ShowNews newsInfo = null;
            //泛型列表存储一下分类列表返回
            List<ShowNews> newsList = new List<ShowNews>();
            while (dr.Read())
            {
                newsInfo = new ShowNews();
                newsInfo.id = dr.GetInt32(0);
                newsInfo.title = dr.GetString(1);
                newsInfo.createtime = dr.GetDateTime(2);
                newsInfo.img = dr.GetString(3);
                newsInfo.userAvatar = dr.GetString(4);
                newsInfo.nickName = dr["nickName"].ToString() ?? "";
                newsInfo.catename = dr.GetString(6);
                //把获取到的分类存到泛型列表中
                newsList.Add(newsInfo);
            }
            //关闭我们的读取连接
            dr.Close();
            //返回用户信息
            return newsList;
        }

        //关联表查询获取数据回来
        public static List<News> getNewsList()
        {
            string sql = "select n.id,n.title,n.createtime,n.img,u.userAvatar,u.nickName,c.catename from News n left join [user] u on n.user_id = u.id left join category c on n.category_id = c.id  order by createtime desc";
            SqlDataReader dr = DBHelper.getData(sql);
            List<News> list = new List<News>();
            News news = null;
            while(dr.Read())
            {
                news = new News()
                {
                    id = dr.GetInt32(0),
                    title = dr.GetString(1),
                    createtime = dr.GetDateTime(2),
                    img = dr.GetString(3),
                    
                };
                list.Add(news);
            }
            dr.Close();
            return list;
        }


        //查询数据：查询新闻表中的新闻信息 【通过新闻ID，查询单条新闻回来】
        public static News getNewsDetail(int newsId)
        {
            //1、查询sql，传新闻的id获取对应新闻的详情
            string sql = string.Format("select * from news where id='{0}'", newsId);
            //2、获取新闻回来
            SqlDataReader dr = DBHelper.getData(sql);
            News detail = null;
            if(dr.Read())
            {
                detail = new News();
                detail.id = dr.GetInt32(0);
                detail.title = dr["title"].ToString();
                detail.content = dr["content"].ToString();
                detail.user_id = int.Parse(dr["user_id"].ToString());
                detail.createtime = DateTime.Parse(dr["createtime"].ToString());
            }
            //关闭连接
            dr.Close();

            return detail;
        }

        //添加新闻
        public static bool addNews(News news)
        {
            //执行插入sql
            string sql = string.Format("insert into News(title,content,category_id,img,user_id,state,createtime) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", news.title,news.content,news.category_id,news.img,news.user_id, news.state, news.createtime);
            //执行插入sql
            return DBHelper.updateData(sql);
        }
    }
}
