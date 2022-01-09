using COMMON;
using DataAccess.Context;
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
    public class ProductController : Controller
    {
        AppDbContext db = new AppDbContext();

        
        ProductService productService = new ProductService();
        // GET: Administrator/Product
        public ActionResult Index()
        {
            return View(productService.GetList());
        }

        // GET: Administrator/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrator/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Product/Create
        [HttpPost]
        public ActionResult Create(ProductVM productVM, HttpPostedFileBase ImagePath)
        {
            try
            {
                Product product = new Product();
                product.ProductName = productVM.ProductName;
                product.UnitPrice = productVM.UnitPrice;
                product.UnitsInStock = productVM.UnitsInStock;
                product.SubCategoryId = Guid.Parse("1CA16451-78ED-473D-B0FB-23B2E1A1FF47");
                product.ImagePath = ImageUploader.UploadImage("~/Content/dist/product/", ImagePath);

                productService.Create(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/Product/Edit/5
        public ActionResult Edit(Guid id)
        {

            var product = productService.GetById(id);

            return View("Edit", product);


            
        }

        // POST: Administrator/Product/Edit/5
        [HttpPost]
        public ActionResult Edit( Product productVM,HttpPostedFileBase ImagePath)
        {
            try
            {
                Product product = new Product();

                product.ID = productVM.ID;
                product.ProductName = productVM.ProductName;
                product.UnitPrice = productVM.UnitPrice;
                product.UnitsInStock = productVM.UnitsInStock;
                product.SubCategoryId= Guid.Parse("1CA16451-78ED-473D-B0FB-23B2E1A1FF47");
                product.ImagePath = ImageUploader.UploadImage("~/Content/dist/product", ImagePath);
                product.Status = CORE.Enum.Status.Modified;


                productService.Update(product);
                db.SaveChanges();









                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrator/Product/Delete/5
        public ActionResult Delete(Guid id)
        {
            var product = productService.GetById(id);

            
           
            productService.Delete(product);



            return RedirectToAction("Index");
        }

        // POST: Administrator/Product/Delete/5
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
