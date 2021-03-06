﻿using System;
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
    public class ProductController : Controller
    {
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<Product> GetProductList(int page, int pageSize, string type)
        {
            string conditions = "";
            if (type != null)
            {
                conditions = string.Format("where tag like N'%{0}%'", type);
            }
            var productList = new ProductDao().GetListPaged(page, pageSize, conditions, null);
            foreach (var item in productList)
            {
                item.imgList = new ImageDao().GetImageList(item.Id, 6);
            }
            return new RestfulArray<Product>
            {
                data = productList,
                total = new ProductDao().RecordCount(conditions)

            };
        }

        /// <summary>
        /// 获取单个产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<Product> Get(int id)
        {
            var data = new ProductDao().Get(id);
            data.imgList = new ImageDao().GetImageList(id, 1);
            return new RestfulData<Product>
            {
                data = data
            };
        }

        /// <summary>
        /// 新增产品
        /// </summary>
        /// <param name="product"></param>
        [HttpPost]
        public RestfulData PostProduct([FromBody]Product product)
        {
            int productId = new ProductDao().insertProduct(product) ?? 0;
            if (productId != 0)
            {
                new ImageDao().InsertImageList(product.imgList, product.Id, 1);
            }

            return new RestfulData
            {
                message = "新增成功"
            };
        }



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public RestfulData PutProduct([FromBody]Product product)
        {
            new ProductDao().Update(product);
            new ImageDao().UpdateImageList(product.imgList, product.Id, 1);
            return new RestfulData
            {
                message = "更新成功！"
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public RestfulData DeleteProduct(int id)
        {
            new ProductDao().deleteProduct(id);
            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
