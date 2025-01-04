using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Service;

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
                try
                {
                    var products = db.Products.ToList(); // Lấy tất cả các sản phẩm từ cơ sở dữ liệu

                    return View(products); // Trả về danh sách sản phẩm cho View
                } catch (Exception ex)
                {
                    ProductService productService = new ProductService();
                    var products = productService.GetAll();
                    return View(products);
                }
            }

            //ProductConnector connector = new ProductConnector();
            //var products = connector.GetAll();
            //return View(products);

        }
    }
}