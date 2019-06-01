using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ygl.Models.RestfulData;
using ygl.Utils;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        [Authorize]
        public RestfulData<User> GetUser()
        {
            
            var data=  new UserDao().Get(Helper.GetCurrentUser(HttpContext).Id);
            data.TagList = data.Tag.Split('|');
            return new RestfulData<User>
            {
                data=data
            };
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user">用户实体</param>
        [HttpPost]
        public RestfulData PostUser([FromBody]User user)
        {
            user.Tag = string.Join("|", user.TagList);
            new UserDao().Insert(user);
            return new RestfulData
            {
                message = "注册成功!"
            };
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public RestfulData Put([FromBody]User user)
        {
            user.Tag = string.Join("|", user.TagList);
            new UserDao().Update(user);
            return new RestfulData
            {

            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new UserDao().deleteUser(id);
        }
    }
}
