using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        // GET: All Products
        public ActionResult Index()
        {
            // Load all products from the database
            using (var db = new MyDbContext())
            {
                var products = db.Products.ToList(); // Lấy tất cả các sản phẩm từ cơ sở dữ liệu
                return View(products); // Trả về danh sách sản phẩm cho View
            }
        }

        // GET: Product Details by ID
        public ActionResult Details(int id)
        {
            // Load product by ID from the database
            using (var db = new MyDbContext())
            {
                var product = db.Products.FirstOrDefault(p => p.Id == id); // Lấy sản phẩm với ID tương ứng
                if (product == null)
                {
                    return HttpNotFound(); // Nếu không tìm thấy sản phẩm, trả về lỗi 404
                }
                return View(product); // Trả về sản phẩm cho View
            }
        }

        // GET: Create
        public ActionResult Create()
        {
            var model = new ProductViewModel
            {
                Sizes = new List<SizeOption>
            {
                new SizeOption { Size = "S", IsSelected = false },
                new SizeOption { Size = "M", IsSelected = false },
                new SizeOption { Size = "L", IsSelected = false },
                new SizeOption { Size = "XL", IsSelected = false }
            }
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SelectedSizes = string.Join(",", model.Sizes.Where(s => s.IsSelected).Select(s => s.Size));

                using (var db = new MyDbContext())
                {
                    var product = new Product
                    {
                        Name = model.Name,
                        Price = model.Price,
                        Description = model.Description,
                        Color = model.Color,
                        Quantity = model.Quantity,
                        Size = model.SelectedSizes,
                        Category = model.Category,
                        Sex = model.Sex
                    };

                    db.Products.Add(product);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            using (var db = new MyDbContext())
            {
                var product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }

                var model = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Color = product.Color,
                    Quantity = product.Quantity,
                    Category = product.Category,
                    Sex = product.Sex,
                    Sizes = new List<SizeOption>
            {
                new SizeOption { Size = "S", IsSelected = product.Size?.Contains("S") ?? false },
                new SizeOption { Size = "M", IsSelected = product.Size?.Contains("M") ?? false },
                new SizeOption { Size = "L", IsSelected = product.Size?.Contains("L") ?? false },
                new SizeOption { Size = "XL", IsSelected = product.Size?.Contains("XL") ?? false }
            }
                };

                return View(model);
            }
        }


        // POST: Edit
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MyDbContext())
                {
                    var product = db.Products.Find(model.Id);
                    if (product == null)
                    {
                        return HttpNotFound(); // Nếu không tìm thấy sản phẩm, trả về lỗi 404.
                    }

                    // Cập nhật các thuộc tính của sản phẩm.
                    product.Name = model.Name;
                    product.Price = model.Price;
                    product.Description = model.Description;
                    product.Color = model.Color;
                    product.Quantity = model.Quantity;
                    product.Category = model.Category;
                    product.Sex = model.Sex;

                    // Cập nhật danh sách kích thước đã chọn và chuyển thành chuỗi
                    product.Size = string.Join(",", model.Sizes.Where(s => s.IsSelected).Select(s => s.Size));

                    db.SaveChanges(); // Lưu các thay đổi vào cơ sở dữ liệu.
                }

                return RedirectToAction("Index"); // Chuyển hướng về trang danh sách sản phẩm sau khi cập nhật thành công.
            }

            return View(model); // Nếu có lỗi, trả về lại view để người dùng sửa.
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            using (var db = new MyDbContext())
            {
                var product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound(); // Nếu không tìm thấy sản phẩm, trả về lỗi 404.
                }

                return View(product); // Trả về view với sản phẩm cần xóa.
            }
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new MyDbContext())
            {
                var product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound(); // Nếu không tìm thấy sản phẩm, trả về lỗi 404.
                }

                db.Products.Remove(product); // Xóa sản phẩm.
                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu.
            }

            return RedirectToAction("Index"); // Chuyển hướng về trang danh sách sản phẩm sau khi xóa thành công.
        }


    }
}