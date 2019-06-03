using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ygl.Models.RestfulData;
using yglAPI.DbHelper;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        /// <summary>
        /// 获取游记列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<Order> GetOrderList(int page, int pageSize)
        {

            var orderList = new OrderDao().GetListPaged(page, pageSize, null, null);
           
            return new RestfulArray<Order>
            {
                data = orderList,
                total = new OrderDao().RecordCount()

            };
        }

        /// <summary>
        /// 获取单个订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<Order> Get(int id)
        {
            var data = new OrderDao().Get(id);
           
            return new RestfulData<Order>
            {
                data = data
            };
        }

      



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public RestfulData PutOrder([FromBody]Order order)
        {
            new OrderDao().Update(order);
           
            return new RestfulData
            {
                message = "更新成功！"
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public RestfulData DeleteOrder(int id)
        {
            new OrderDao().deleteOrder(id);
            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
