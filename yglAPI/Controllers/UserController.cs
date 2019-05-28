using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ygl.Models.RestfulData;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return new UserDao().Get(id);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user">用户实体</param>
        [HttpPost]
        public RestfulData PostUser([FromBody]User user)
        {
            new UserDao().insertUser(user);
            return new RestfulData
            {
                message = "注册成功"
            };
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]User user)
        {
            new UserDao().Update(user);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new UserDao().deleteUser(id);
        }
    }
}
