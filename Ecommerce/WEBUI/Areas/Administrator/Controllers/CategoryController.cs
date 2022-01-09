
using DataAccess.Entity;
using SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBUI.Models.ViewModels;

namespace WEBUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
        // GET: Administrator/Category
        public ActionResult Index()
        {
            return View(categoryService.GetList());
        }

        //Get Products with categoryId
        public PartialViewResult _GetProducts(Guid id)
        {
            //Todo: aşağıdaki işleme karşılık gelen vir ViewModel oluşturun.
            ProductService productService = new ProductService();
            SubCategoryService subCategoryService = new SubCategoryService();
            var subCategory=subCategoryService.GetDefault(x => x.CategoryId == id);
            List<Product> productList=new List<Product>();
            foreach (var sub in subCategory)
            {
              productList= productService.GetDefault(x => x.SubCategoryId == sub.ID);
            }
            return PartialView(productList);
        }

        // GET: Administrator/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrator/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Category/Create
        [HttpPost]
        public ActionResult Create(CategoryVM collection)
        {
            
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrator/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrator/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
