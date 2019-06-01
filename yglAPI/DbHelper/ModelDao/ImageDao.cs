using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models;

namespace yglAPI.DbHelper
{
    public class ImageDao : DaoBase<Img, Int32>
    {
        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="toId">对应id</param>
        /// <param name="type">类型（1.景点,2.美食，3.游记，4.新闻，5.头像,6.产品,7.评论）</param>
        /// <returns></returns>
        public List<string> GetImageList(int toId,int type)
        {
            List<string> list=new List<string>();
            var imgList = GetList("where toId=@toId and type=@type", new { toId, type });
            foreach(var img in imgList)
            {
                list.Add(img.Url);
            }
            return list;
        }
        /// <summary>
        /// 将图片url数组存入数据库
        /// </summary>
        /// <param name="imgList">url数组</param>
        /// <param name="toId">对应id</param>
        /// <param name="type">类型（1.景点,2.美食，3.游记，4.新闻，5.头像,6.产品,7.评论）</param>
        /// <returns></returns>
        public int InsertImageList(IEnumerable<string> imgList, int toId, int type)
        {
            int i = 0;
            foreach(var item in imgList)
            {
                i += Insert(new Img { Url = item, toId = toId, Type = type })??0;
            }
            return i;
        }

        /// <summary>
        /// 更新图片url
        /// </summary>
        /// <param name="imgList"></param>
        /// <param name="toId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int UpdateImageList(IEnumerable<string> imgList, int toId, int type)
        {
            int i = 0;
            DeleteList("where toId=@toId and type=@type", new { toId, type });
            return InsertImageList(imgList, toId, type);
        }

    }
}
