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
    public class FoodController : Controller
    {
        /// <summary>
        /// 获取美食列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<Food> GetFoodList(int page, int pageSize)
        {
            
            var foodList = new FoodDao().GetListPaged(page, pageSize, null, null);
            foreach (var item in foodList)
            {
                item.imgList = new ImageDao().GetImageList(item.Id, 2);
            }
            return new RestfulArray<Food>
            {
                data = foodList,
                total = new FoodDao().RecordCount()

            };
        }

        /// <summary>
        /// 获取单个美食
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<Food> Get(int id)
        {
            var data = new FoodDao().Get(id);
            data.imgList = new ImageDao().GetImageList(id, 1);
            return new RestfulData<Food>
            {
                data = data
            };
        }

        /// <summary>
        /// 新增美食
        /// </summary>
        /// <param name="food"></param>
        [HttpPost]
        public RestfulData PostFood([FromBody]Food food)
        {
            int foodId = new FoodDao().insertFood(food) ?? 0;
            if (foodId != 0)
            {
                new ImageDao().InsertImageList(food.imgList, food.Id, 1);
            }

            return new RestfulData
            {
                message = "新增成功"
            };
        }



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public RestfulData PutFood([FromBody]Food food)
        {
            new FoodDao().Update(food);
            new ImageDao().UpdateImageList(food.imgList, food.Id, 1);
            return new RestfulData
            {
                message = "更新成功！"
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public RestfulData DeleteFood(int id)
        {
            new FoodDao().deleteFood(id);
            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
