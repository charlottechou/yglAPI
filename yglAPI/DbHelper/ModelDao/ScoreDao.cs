using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models;

namespace yglAPI.DbHelper.ModelDao
{
    public class ScoreDao : DaoBase<Score, Int32>
    {
        public int? insertScore(Score score)
        {
            return this.Insert(score);
        }

        public int deleteScore(int id)
        {
            return this.Delete(id);
        }

        public Score getScore(int id)
        {
            return this.Get(id);
        }
    }
}
