using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Njd.Bakery.Repository;
using Njd.Bakery.Repository.EfModels;
using System.Collections.Generic;
using System.Linq;

namespace Njd.Bakery.Api2.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BakeryContext _context;

        public ProductsController(BakeryContext context)
        {
            _context = context;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Classification)
                .Include(p => p.ProductVariations)
                .Include(p => p.ProductIngredients)
                    .ThenInclude(pi => pi.Ingredient);

            return Ok(products);
        }

        // GET api/products/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Classification)
                .Include(p => p.ProductVariations)
                .Include(p => p.ProductIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .FirstOrDefault(p => p.Id == id);

            return product == null ?
                (ActionResult<Product>)NotFound($"Product not found for id: {id}") :
                Ok(product);
        }

        // GET api/products/categories
        [HttpGet("categories")]
        public ActionResult<IEnumerable<string>> GetProductCategories()
        {
            return Ok(_context.ProductCategories.OrderBy(x => x.Name).ToList());
        }

        // GET api/products/classifications
        [HttpGet("classifications")]
        public ActionResult<IEnumerable<string>> GetProductClassifications()
        {
            return Ok(_context.ProductClassifications.OrderBy(x => x.Name).ToList());
        }

        //[HttpPost]
        //public ActionResult<int> CreateProduct()
        //{
        //    var ingredients = _context.Ingredients.ToList();

        //    var newProduct = new Product
        //    {
        //        Name = "Chocolate chip cookies",
        //        CanBeEggFree = true,
        //        DefaultNumberOfServings = 12,
        //        Sku = "chocChipCookieSku",
        //        TotalBatchCalories = 1200,
        //        TotalBatchCarbs = 200,
        //        TotalBatchFat = 500,
        //        TotalBatchFiber = 150,
        //        TotalBatchProtein = 75,
        //        TotalBatchSugar = 600,
        //        Ingredient
        //    }
        //}
    }
}
