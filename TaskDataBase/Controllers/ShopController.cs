using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskDataBase.Context;
using TaskDataBase.Models.Entity.Conceretes;
using TaskDataBase.Models.ViewModel;

namespace TaskDataBase.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopDbContext _context;

        public ShopController(ShopDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            var prViewModel = products.Select(p => new GetAllProdutcViewModel
            {
               Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }).ToList();
            return View(prViewModel);

        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel product)
        {
            var pr = new Product
            {
                
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
            _context.Products.Add(pr);
            _context.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }
    public IActionResult DeleteProduct(int id)
        {
            var pr = _context.Products.FirstOrDefault(p => p.Id == id);
            if (pr != null)
            {
                _context.Products.Remove(pr);
                
            }
            _context.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null)
                return RedirectToAction("GetAllProducts");
            UpdateProductViewModel prViewModel = new UpdateProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
            return View(prViewModel);
        }
        [HttpPost]
        public IActionResult UpdateProduct(int id, UpdateProductViewModel pr)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null)
                return RedirectToAction("GetAllProducts");
            product.Name = pr.Name;
            product.Description = pr.Description;
            product.Price = pr.Price;
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }

        public IActionResult GetAllCategory()
        {
            var category = _context.Categories.ToList();
            var crViewModel = category.Select(p => new GetCategoryViewModel
            {
                Id = p.Id,
                Name = p.Name,
               
            }).ToList();
            return View(crViewModel);

        }


        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel category)
        {
            var cr = new Category
            {
                Name= category.Name,
                
            };
            _context.Categories.Add(cr);
            _context.SaveChanges();
            return RedirectToAction("GetAllCategory");
        }
        public IActionResult DeleteCategory(int id)
        {
            var cr = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (cr != null)
            {
                _context.Categories.Remove(cr);

            }
            _context.SaveChanges();
            return RedirectToAction("GetAllCategory");
        }
        [HttpGet]
       
        public IActionResult UpdateCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category is null)
                return RedirectToAction("GetAllProducts");
            UpdateCategoryViewModel crViewModel = new UpdateCategoryViewModel
            {
                Name = category.Name,
                
            };
            return View(crViewModel);
        }
        [HttpPost]
        public IActionResult UpdateCategory(int id, UpdateCategoryViewModel cr)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null)
                return RedirectToAction("GetAllCategory");
            category.Name = cr.Name;
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("GetAllCategory");
        }
    }
}
