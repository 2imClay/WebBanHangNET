using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            // Load all products from the database
            using (var db = new MyDbContext())
            {
                //var products = db.Products.ToList(); // Lấy tất cả các sản phẩm từ cơ sở dữ liệu

                var products = new List<Product>
    {
                new Product { Name = "Product 1", Price = 100 },
                 new Product { Name = "Product 2", Price = 200 }
    };

                return View(products); // Trả về danh sách sản phẩm cho View
            }
        }
    }
}