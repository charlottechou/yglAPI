using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using ygl.Models.RestfulData;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页个数</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<MyTag> GetTageList(int page,int pageSize)
        {

            return new RestfulArray<MyTag>
            {
                data = new TagDao().GetListPaged(page, pageSize, null, null)
            };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public MyTag Get(int id)
        {
            return new TagDao().Get(id);
        }

        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="tag">标签</param>
        [HttpPost]
        public RestfulData PostMyTag([FromBody]MyTag tag)
        {
            new TagDao().insertTag(tag);
            return new RestfulData
            {
                message = "新增成功"
            };
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="tag">tag对象</param>
        /// <returns></returns>
        [HttpPut]
        public RestfulData Put([FromBody]MyTag tag)
        {
            new TagDao().Update(tag);
            return new RestfulData
            {
                message = "更新成功！"
            };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">tag id</param>
        [HttpDelete("{id}")]
        public RestfulData Delete(int id)
        {
            new TagDao().deleteTag(id);
            return new RestfulData
            {
                message = "删除成功"
            };
        }
    }
}
