using Microsoft.AspNetCore.Mvc;
using Models;

namespace PartialViewsDemo.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> products = new List<Product>();
        public ProductController()
        {
            products = new List<Product>()
            {
                new Product { ProductID =1, Name ="Product 1", Category = "Category 1", Description ="Description 1", Price = 10m},
                new Product { ProductID =2, Name ="Product 2", Category = "Category 1", Description ="Description 2", Price = 20m},
                new Product { ProductID =3, Name ="Product 3", Category = "Category 1", Description ="Description 3", Price = 30m},
                new Product { ProductID =4, Name ="Product 4", Category = "Category 2", Description ="Description 4", Price = 40m},
                new Product { ProductID =5, Name ="Product 5", Category = "Category 2", Description ="Description 5", Price = 50m},
                new Product { ProductID =6, Name ="Product 6", Category = "Category 2", Description ="Description 6", Price = 50m}
            };
        }
        public IActionResult Index()
        {
            return View(products);
        }
        public IActionResult Details(int Id)
        {
            var ProductDetails = products.FirstOrDefault(prd => prd.ProductID == Id);
            return View(ProductDetails);
        }
    }
}
