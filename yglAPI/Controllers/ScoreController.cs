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
    public class ScoreController : Controller
    {
        /// <summary>
        /// 获取评论列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<Score> GetScoreList(int page, int pageSize)
        {
           
            var scoreList = new ScoreDao().GetListPaged(page, pageSize,null, null);
            foreach (var item in scoreList)
            {
                item.imgList = new ImageDao().GetImageList(item.Id, 1);
            }
            return new RestfulArray<Score>
            {
                data = scoreList,
                total = new ScoreDao().RecordCount()

            };
        }


        /// <summary>
        /// 新增评价
        /// </summary>
        /// <param name="score></param>
        [HttpPost]
        public RestfulData PostScore([FromBody]Score score)
        {
            int scoreId = new ScoreDao().insertScore(score) ?? 0;
            if (scoreId != 0)
            {
                new ImageDao().InsertImageList(score.imgList, scoreId, 7);
            }

            return new RestfulData
            {
                message = "新增成功"
            };
        }



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public RestfulData PutScore([FromBody]Score score)
        {
            new ScoreDao().Update(score);
            new ImageDao().UpdateImageList(score.imgList, score.Id, 1);
            return new RestfulData
            {
                message = "更新成功！"
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public RestfulData DeleteScore(int id)
        {
            new ScoreDao().deleteScore(id);
            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
