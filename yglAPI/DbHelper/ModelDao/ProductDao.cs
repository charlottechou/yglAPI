using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ygl.DbHelper;
using yglAPI.Models.Product;

namespace yglAPI.DbHelper.ModelDao
{
    public class ProductDao : DaoBase<Product, Int32>
    {
        public int? insertProduct(Product product)
        {
            return this.Insert(product);
        }

        public int deleteProduct(int id)
        {
            return this.Delete(id);
        }

        public Product getProduct(int id)
        {
            return this.Get(id);
        }
    }
}
