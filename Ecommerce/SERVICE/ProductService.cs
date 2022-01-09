using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE
{
    public class ProductService:BaseService<Product>
    {
        
        //Sadece ürünlere ait işlemler
        public List<Product> GetActiveProducts()
        {
            var products = this.GetDefault(x => x.Status == CORE.Enum.Status.Active || x.Status == CORE.Enum.Status.Modified);
            return products;
        }
    }
}
