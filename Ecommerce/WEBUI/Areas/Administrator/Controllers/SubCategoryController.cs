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
    public class SubCategoryController : Controller
    {
        SubCategoryService subCategoryService = new SubCategoryService();

        // GET: Administrator/SubCategory
        public ActionResult Index()
        {
            return View(subCategoryService.GetList());
        }

        // GET: Administrator/SubCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrator/SubCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/SubCategory/Create
        [HttpPost]
        public ActionResult Create(SubCategoryVM subCategoryVM)
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

        // GET: Administrator/SubCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrator/SubCategory/Edit/5
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

        // GET: Administrator/SubCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrator/SubCategory/Delete/5
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
