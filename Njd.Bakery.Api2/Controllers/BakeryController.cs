using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Njd.Bakery.Api.Controllers.Models;
using Njd.Bakery.Repository;
using Njd.Bakery.Repository.EfModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Njd.Bakery.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BakeryContext _context;

        public ProductsController(BakeryContext context)
        {
            _context = context;
        }

        // GET api/products
        [HttpGet("products")]
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
        [HttpGet("products/{id}")]
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
        [HttpGet("products/categories")]
        public ActionResult<IEnumerable<string>> GetProductCategories()
        {
            return Ok(_context.ProductCategories.OrderBy(x => x.Name).ToList());
        }

        // GET api/classifications
        [HttpGet("products/classifications")]
        public ActionResult<IEnumerable<string>> GetProductClassifications()
        {
            return Ok(_context.ProductClassifications.OrderBy(x => x.Name).ToList());
        }

        // POST api/ingredients
        [HttpPost("ingredients")]
        public async Task<IActionResult> CreateIngredients(IEnumerable<string> ingredientNames)
        {
            var ingredients = ingredientNames.Select(ingredientName => new Ingredient { Name = ingredientName }).ToList();
            _context.Ingredients.AddRange(ingredients);
            await _context.SaveChangesAsync();
            return Created("", ingredients);
        }

        // POST api/products/ingredients
        [HttpPost("products/ingredients")]
        public async Task<IActionResult> CreateProductIngredients(CreateProductIngredientsRequest req)
        {
            var product = await _context.Products
                .Include(p => p.ProductIngredients)
                .FirstOrDefaultAsync(p => p.Id == req.ProductId);
            if (product == null)
            {
                return NotFound("Product Not Found");
            }

            var ingredients = req.IngredientIds.Select(id => _context.Ingredients.FirstOrDefault(i => i.Id == id)).Where(ing => ing != null).ToList();

            foreach (var ingredient in ingredients)
            {
                product.ProductIngredients.Add(new ProductIngredient { Ingredient = ingredient });
            }

            await _context.SaveChangesAsync();

            return Created("", product);
        }
    }
}
