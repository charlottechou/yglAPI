using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models.News;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public News Get(int id)
        {
           return  new NewsDao().Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]News news)
        {
            new NewsDao().insertNews(news);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put([FromBody]News news)
        {
            new NewsDao().Update(news);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new NewsDao().deleteNews(id);
        }
    }
}
