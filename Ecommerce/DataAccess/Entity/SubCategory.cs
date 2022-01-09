using CORE;
using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public class SubCategory:CoreEntity
    {
        public string SubCategoryName { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
