using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Njd.Bakery.Repository;
using Njd.Bakery.Repository.EfModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Njd.Bakery.Api.Controllers
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

        // TODO: begin on sunday by trying to figure out why the foreign keys are being generated backwards in the productingredients table

        // api/products/pi
        [HttpPost("pi")]
        public async Task<ActionResult<Product>> CreateProductIngredient()
        {
            var cat = await _context.ProductCategories.FirstOrDefaultAsync(pc => pc.Name == "Cookies");
            var cl = await _context.ProductClassifications.FirstOrDefaultAsync(pc => pc.Name == "Simple Dessert");
            var ingredients = await _context.Ingredients.ToListAsync();
            await AddProducts(cat, cl);

            var product = await _context.Products.FirstAsync(p => p.Name == "Chocolate Chip Cookies");

            foreach (var ingredient in ingredients)
            {
                // add ingredients to product variation (except for flour)
                if (ingredient.Name.ToLower().Trim() != "flour")
                {
                    product.ProductVariations.FirstOrDefault()
                        ?.ProductIngredients.Add(
                        new ProductIngredient
                        {
                            Ingredient = ingredient,
                            Product = product.ProductVariations.FirstOrDefault()
                        });
                }

                // add ingredients to product
                product.ProductIngredients.Add(new ProductIngredient
                {
                    Ingredient = ingredient,
                    Product = product
                });
            }
            await _context.SaveChangesAsync();
            return product;
        }

        private async Task AddProducts(ProductCategory cat, ProductClassification cl)
        {
            _context.Products.Add(new Product
            {
                Name = "Chocolate Chip Cookies",
                Classification = cl,
                Category = cat,
                Sku = "Normal Choc Chip Cookie Sku",
                ProductVariations = new List<Product>
                {
                    new Product
                {
                    Name = "cookie variation",
                    Sku = "cookie variation sku",
                    Category = cat,
                    Classification = cl
                }}
            });
            await _context.SaveChangesAsync();
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get(bool? parentsOnly)
        {
            var productsQuery = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Classification)
                .Include(p => p.ProductVariations)
                .Include(p => p.ProductIngredients)
                    .ThenInclude(pi => pi.Ingredient)
                .AsQueryable();

            if (parentsOnly == true)
            {
                productsQuery = productsQuery.Where(p => p.ParentId == null);
            }

            return Ok(productsQuery);
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

    }
}
