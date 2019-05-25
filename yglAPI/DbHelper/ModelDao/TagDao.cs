using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models;

namespace yglAPI.DbHelper.ModelDao
{
    public class TagDao : DaoBase<MyTag, Int32>
    {
        public int? insertTag(MyTag tag)
        {
            return this.Insert(tag);
        }

        public int deleteTag(int id)
        {
            return this.Delete(id);
        }

        public MyTag getTag(int id)
        {
            return this.Get(id);
        }

    }
}
