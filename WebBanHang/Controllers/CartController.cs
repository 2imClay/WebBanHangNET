using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class CartController : Controller
    {
        private static Cart cart = new Cart(); // Dùng tạm thời, có thể thay bằng session hoặc database

        // Hiển thị giỏ hàng
        public ActionResult Index()
        {
            return View(cart);
        }

        // Thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int productId, string productName, decimal price, string size, string color, int quantity)
        {
            var item = new CartItem
            {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                Size = size,
                Color = color,
                Quantity = quantity
            };

            cart.AddToCart(item);
            return RedirectToAction("Index");
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public ActionResult RemoveFromCart(int productId)
        {
            cart.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }

        // Thanh toán giỏ hàng (thực hiện theo yêu cầu)
        public ActionResult Checkout()
        {
            // Thực hiện thanh toán
            cart.ClearCart();
            return View();
        }
    }

}