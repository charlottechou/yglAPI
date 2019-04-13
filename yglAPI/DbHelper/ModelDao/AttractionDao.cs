using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models.Attraction;

namespace yglAPI.DbHelper.ModelDao
{
    public class AttractionDao : DaoBase<Attraction, Int32>
    {
        public int? insertAttraction(Attraction attraction)
        {
            return this.Insert(attraction);
        }

        public int deleteAttraction(int id)
        {
            return this.Delete(id);
        }

        public Attraction getAttraction(int id)
        {
            return this.Get(id);
        }
    }
}
