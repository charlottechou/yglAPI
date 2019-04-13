using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models.Tag;

namespace yglAPI.DbHelper.ModelDao
{
    public class TagDao : DaoBase<myTag, Int32>
    {
        public int? insertTag(myTag tag)
        {
            return this.Insert(tag);
        }

        public int deleteTag(int id)
        {
            return this.Delete(id);
        }

        public myTag getTag(int id)
        {
            return this.Get(id);
        }

    }
}
