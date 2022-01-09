using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBUI.Models.ViewModels
{
    public class ProductVM
    {
       
        public Guid ID { get; set; }
       
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid SubCategoryId { get; set; }
        public short UnitsInStock { get; set; }

    }
}