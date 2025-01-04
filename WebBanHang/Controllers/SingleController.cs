using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class SingleController : Controller
    {
        // GET: Single/Index
        public ActionResult Index()
        {
            ProductConnector productConnector = new ProductConnector();
            List<Product> products = productConnector.GetAll();  // Giả sử bạn có phương thức GetAll để lấy tất cả sản phẩm
            return View(products);  // Truyền danh sách sản phẩm vào view
        }

        // GET: Single/Details/5
        public ActionResult Details(int id)
        {
            ProductConnector connector = new ProductConnector();
            Product product = connector.GetById(id);

            if (product == null)
            {
                return HttpNotFound();  // Nếu không tìm thấy sản phẩm, trả về lỗi 404
            }

            return View(product);  // Trả về view chi tiết sản phẩm
        }
    }
}
