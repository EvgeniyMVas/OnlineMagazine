using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineMagazine.Models;
using System.Diagnostics;

namespace OnlineMagazine.Controllers
{
    public class HomeController : Controller
    {
       public static List<Product> products = new List<Product>()
        {

            new Product(){Id=Guid.NewGuid(),Name="Pepsi 0.5",Description="Тонизирующий напиток",
                Category="Безалкогольные напитки",Price=16},
            new Product(){Id=Guid.NewGuid(),Name="Cola 0.5",Description="Тонизирующий напиток",
                Category="Безалкогольные напитки",Price=14},
            new Product(){Id=Guid.NewGuid(),Name="Fanta 0.5",Description="Тонизирующий напиток",
                Category="Безалкогольные напитки",Price=18},
            new Product(){Id=Guid.NewGuid(),Name="Sprite 0.5",Description="Тонизирующий напиток",
                Category="Безалкогольные напитки",Price=15},
            new Product(){Id=Guid.NewGuid(),Name="Stella 0.5",Description="Пиво",
                Category="Слабоалкогольные напитки",Price=36},
            new Product(){Id=Guid.NewGuid(),Name="Staropramen 0.5",Description="Пиво",
                Category="Слабоалкогольные напитки",Price=28},
            new Product(){Id=Guid.NewGuid(),Name="Bile 0.5",Description="Пиво",
                Category="Слабоалкогольные напитки",Price=26},
            new Product(){Id=Guid.NewGuid(),Name="Obolon 0.5",Description="Пиво",
                Category="Слабоалкогольные напитки",Price=24},
            new Product(){Id=Guid.NewGuid(),Name="Jameson 0.5",Description="Купажируемый ирландский виски",
                Category="Алкогольные напитки",Price=456},
            new Product(){Id=Guid.NewGuid(),Name="Jack Daniels 0.5",Description="Американский виски",
                Category="Алкогольные напитки",Price=512},
            new Product(){Id=Guid.NewGuid(),Name="Red Label 0.5",Description="Янтарный золотистый виски",
                Category="Алкогольные напитки",Price=430},
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(Guid id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }
        public IActionResult Edit(Guid id)
            {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var product = products.FirstOrDefault(p => p.Id == model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Category = model.Category;
                product.Price = model.Price;
            }

            return RedirectToAction("Index", new { id = model.Id });
        }
    }
}
