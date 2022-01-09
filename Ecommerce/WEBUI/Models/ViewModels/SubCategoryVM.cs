using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBUI.Models.ViewModels
{
    public class SubCategoryVM
    {
        [Required(ErrorMessage ="can not empty subcategory name")]
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
    }
}