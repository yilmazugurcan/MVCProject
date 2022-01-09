using COMMON;
using DataAccess.Entity;
using SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WEBUI.Models.ViewModels;

namespace WEBUI.Controllers
{
    public class HomeController : Controller
    {
        ProductService productService = new ProductService();
        AppUserService userService = new AppUserService();
        public ActionResult Index()
        {

           

            //Admin panel için;
            //https://adminlte.io/

            // Product product = new Product();
            // product.ProductName = "Test Product";
            // product.UnitPrice = 50;
            // product.SubCategoryId = Guid.Parse("1ca16451-78ed-473d-b0fb-23b2e1a1ff47");

            //var result= productService.Create(product);

            // var products = productService.GetList();


            return View(productService.GetActiveProducts());
        }

        public PartialViewResult _NavbarPartial()
        {
            CategoryService categoryService = new CategoryService();
            return PartialView(categoryService.GetDefault(x=>x.Status==CORE.Enum.Status.Active||x.Status==CORE.Enum.Status.Modified));
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetDefault(x => x.Username == loginVM.Username && x.Password == loginVM.Password).FirstOrDefault();
                if (user != null)
                {
                    //FormsAuthentication.SetAuthCookie(user.Username, true);
                    WebCookie.SetCookie(user.Username);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(loginVM);
                }
            }
            else
            {
                return View(loginVM);
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}