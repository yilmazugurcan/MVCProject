using CORE;
using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public class Product:CoreEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        //public List<string> ImagePaths { get; set; }

        //Mapping
        public Guid SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
