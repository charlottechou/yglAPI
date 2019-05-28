﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using ygl.Models.RestfulData;
using yglAPI.DbHelper.ModelDao;
using yglAPI.Models;
using zatbAPI.DbHelper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace yglAPI.Controllers
{
    [Route("api/[controller]")]
    public class AttractionController : Controller
    {
        /// <summary>
        /// 获取景点列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <param name="type">景点类型（1.XX景点,2.YY景点）</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<Attraction> GetAttractionList(int page,int pageSize,string type)
        {
            string conditions = "";
            if (type != null)
            {
                conditions= string.Format("where tag like N'%{0}%'", type); 
            }
            var attractionList = new AttractionDao().GetListPaged(page, pageSize, conditions, null);
            foreach(var item in attractionList)
            {
                item.imgList = new ImageDao().GetImageList(item.Id, 1);
            }
            return new RestfulArray<Attraction>
            {
                data = attractionList,
                total = new AttractionDao().RecordCount(conditions)

            };
        }

        /// <summary>
        /// 获取个景点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<Attraction>  Get(int id)
        {
            var data= new AttractionDao().Get(id);
            data.imgList = new ImageDao().GetImageList(id, 1);
            return new RestfulData<Attraction>
            {
                data = data
            };
        }

        /// <summary>
        /// 新增景点
        /// </summary>
        /// <param name="attraction"></param>
        [HttpPost]
        public RestfulData PostAttraction([FromBody]Attraction attraction)
        {
            int attractionId=  new AttractionDao().insertAttraction(attraction)??0;
            if (attractionId != 0)
            {
                new ImageDao().InsertImageList(attraction.imgList, attractionId, 1);
            }
            
            return new RestfulData
            {
                message = "新增成功"
            };
        }



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public RestfulData PutAttraction([FromBody]Attraction attraction)
        {
            new AttractionDao().Update(attraction);
            new ImageDao().UpdateImageList(attraction.imgList, attraction.Id, 1);
            return new RestfulData
            {
                message = "更新成功！"
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public RestfulData DeleteAttraction(int id)
        {
            new AttractionDao().deleteAttraction(id);
            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
