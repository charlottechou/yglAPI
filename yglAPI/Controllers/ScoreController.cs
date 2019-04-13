using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models.Score;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class ScoreController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Score Get(int id)
        {
            return new ScoreDao().Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Score score)
        {
            new ScoreDao().insertScore(score);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put([FromBody]Score score)
        {
            new ScoreDao().Update(score);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ScoreDao().deleteScore(id);
        }
    }
}
