using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBUI.Models.ViewModels
{
    public class CategoryVM
    {
        [Required(ErrorMessage ="Can not empty category name!")]
        public Guid ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}