using SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBUI.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        public ActionResult GetProductsSubCategory(Guid id)
        {
            var products = productService.GetActiveProducts();

            ViewBag.SubCategory = productService.GetDefault(x => x.SubCategoryId == id).FirstOrDefault().SubCategory.SubCategoryName;
            return View(products.Where(x=>x.SubCategoryId==id).ToList());
        }

      
    }
}