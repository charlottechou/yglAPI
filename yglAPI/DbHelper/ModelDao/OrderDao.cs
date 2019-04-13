using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models.Order;

namespace yglAPI.DbHelper.ModelDao
{
    public class OrderDao : DaoBase<Order, Int32>
    {
        public int? insertOrder(Order order)
        {
            return this.Insert(order);
        }

        public int deleteOrder(int id)
        {
            return this.Delete(id);
        }

        public Order getOrder(int id)
        {
            return this.Get(id);
        }
    }
}
