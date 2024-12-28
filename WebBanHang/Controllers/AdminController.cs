using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class AdminController : Controller
    {
        private MyDbContext db = new MyDbContext();

        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }
    }

}