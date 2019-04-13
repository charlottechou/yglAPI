using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models.Attraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class AttractionController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Attraction  Get(int id)
        {
            return new AttractionDao().Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Attraction attraction)
        {
            new AttractionDao().insertAttraction(attraction);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put([FromBody]Attraction attraction)
        {
            new AttractionDao().Update(attraction);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new AttractionDao().deleteAttraction(id);
        }
    }
}
