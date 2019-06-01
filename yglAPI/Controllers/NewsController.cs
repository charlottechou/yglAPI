using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using ygl.Models.RestfulData;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models;
using yglAPI.DbHelper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        /// <summary>
        /// 获取新闻列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<News> GetNewsList(int page, int pageSize)
        {
           
            var newsList = new NewsDao().GetListPaged(page, pageSize, null, null);
            foreach (var item in newsList)
            {
                item.imgList = new ImageDao().GetImageList(item.Id, 4);
            }
            return new RestfulArray<News>
            {
                data = newsList,
                total = new NewsDao().RecordCount()

            };
        }

        /// <summary>
        /// 获取单个新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<News> Get(int id)
        {
            var data = new NewsDao().Get(id);
            data.imgList = new ImageDao().GetImageList(id, 1);
            return new RestfulData<News>
            {
                data = data
            };
        }

        /// <summary>
        /// 新增新闻
        /// </summary>
        /// <param name="news"></param>
        [HttpPost]
        public RestfulData PostNews([FromBody]News news)
        {
            int newsId = new NewsDao().insertNews(news) ?? 0;
            if (newsId != 0)
            {
                new ImageDao().InsertImageList(news.imgList, news.Id, 1);
            }

            return new RestfulData
            {
                message = "新增成功"
            };
        }



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public RestfulData PutNews([FromBody]News news)
        {
            new NewsDao().Update(news);
            new ImageDao().UpdateImageList(news.imgList, news.Id, 1);
            return new RestfulData
            {
                message = "更新成功！"
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public RestfulData DeleteNews(int id)
        {
            new NewsDao().deleteNews(id);
            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
