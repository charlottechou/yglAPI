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
    public class NoteController : Controller
    {
        /// <summary>
        /// 获取游记列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<Note> GetNoteList(int page, int pageSize)
        {
           
            var noteList = new NoteDao().GetListPaged(page, pageSize, null, null);
            foreach (var item in noteList)
            {
                item.imgList = new ImageDao().GetImageList(item.Id, 3);
            }
            return new RestfulArray<Note>
            {
                data = noteList,
                total = new AttractionDao().RecordCount()

            };
        }

        /// <summary>
        /// 获取单个游记
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<Note> Get(int id)
        {
            var data = new NoteDao().Get(id);
            data.imgList = new ImageDao().GetImageList(id, 1);
            return new RestfulData<Note>
            {
                data = data
            };
        }

        /// <summary>
        /// 新增游记
        /// </summary>
        /// <param name="note"></param>
        [HttpPost]
        public RestfulData PostNote([FromBody]Note note)
        {
            int noteId = new NoteDao().insertNote(note) ?? 0;
            if (noteId != 0)
            {
                new ImageDao().InsertImageList(note.imgList, note.Id, 1);
            }

            return new RestfulData
            {
                message = "发布成功"
            };
        }



        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public RestfulData PutNote([FromBody]Note note)
        {
            new NoteDao().Update(note);
            new ImageDao().UpdateImageList(note.imgList, note.Id, 1);
            return new RestfulData
            {
                message = "更新成功！"
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public RestfulData DeleteNote(int id)
        {
            new NoteDao().deleteNote(id);
            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
