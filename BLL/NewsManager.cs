using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsManager
    {
        //修改新闻的状态
        public static bool updateNewsState(int id,int state)
        {
            //需要校验state状态
            if(state == 1)
            {
                state = 2;
            }
            else
            {
                state = 1; //否则改为通过
            }

            return NewsService.updateNewsState(id,state);
        }
        //获取列表数据回来
        public static List<News> getNewsList(int user_id)
        {
            return NewsService.getNewsList(user_id);
        }

        //取新闻详情回来展示
        public static News getNewsDetail(int id)
        {
            return NewsService.getNewsDetail(id);
        }

        //获取用户相关的新闻信息列表回来
        public static List<News> getUserSendNewsList(int user_id)
        {
            return NewsService.getNewsList(user_id,false);
        }

        //获取首页新闻列表回来
        public static List<ShowNews> getIndexNewsList(int pageNum, int pageSize,int id, string keyword = "")
        {
            return NewsService.getIndexNewsList(pageNum, pageSize,id,keyword);
        }

        //执行保存数据到数据库
        public static bool addNews(News news)
        {
            return NewsService.addNews(news);
        }
    }
}
