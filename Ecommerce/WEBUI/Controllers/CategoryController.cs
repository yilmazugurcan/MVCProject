using SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBUI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult GetSubCategories(Guid id)
        {
            SubCategoryService subCategoryService = new SubCategoryService();
            var subCategories = subCategoryService.GetDefault(x => x.CategoryId == id);
            return View(subCategories);
        }

        public ActionResult GetCategories()
        {

            CategoryService categoryService = new CategoryService();

            var categories = categoryService.GetList();

            return  View (categories);
            


        }
        public ActionResult GetCategory(string name)
        {

            

            ProductService productService = new ProductService();
            var product = productService.GetDefault(x => x.SubCategory.SubCategoryName == name);


            return View(product);


        }
    }
}