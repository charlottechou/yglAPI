using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return new OrderDao().Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Order order)
        {
            new OrderDao().insertOrder(order);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put([FromBody]Order order)
        {
            new OrderDao().Update(order);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new OrderDao().deleteOrder(id);
        }
    }
}
