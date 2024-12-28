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
    }
}