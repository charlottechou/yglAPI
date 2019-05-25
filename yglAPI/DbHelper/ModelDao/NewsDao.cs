using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models;

namespace yglAPI.DbHelper.ModelDao
{
    public class NewsDao : DaoBase<News, Int32>
    {
        public int? insertNews (News news)
        {
            return this.Insert(news);
        }
        public int deleteNews(int id)
        {
            return this.Delete(id);
        }

        public News getNews(int id)
        {
            return this.Get(id);
        }

    }
}
