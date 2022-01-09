

using CORE;
using DataAccess.Entity;

namespace DataAccess.MAP
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            Property(x => x.ProductName).IsRequired().HasMaxLength(250);
            Property(x => x.ImagePath).IsOptional().HasMaxLength(250);
        }
    }
}
