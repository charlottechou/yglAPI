using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models;

namespace yglAPI.DbHelper.ModelDao
{
    public class FoodDao : DaoBase<Food, Int32>
    {
        public int? insertFood(Food food)
        {
            return this.Insert(food);
        }


        public int deleteFood(int id)
        {
            return this.Delete(id);
        }

        public Food getFood(int id)
        {
            return this.Get(id);
        }
    }
}
