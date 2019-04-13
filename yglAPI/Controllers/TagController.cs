using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models.Tag;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public myTag Get(int id)
        {
            return new TagDao().Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]myTag tag)
        {
            new TagDao().insertTag(tag);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put([FromBody]myTag tag)
        {
            new TagDao().Update(tag);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new TagDao().deleteTag(id);
        }
    }
}
