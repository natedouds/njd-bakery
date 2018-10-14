﻿using Microsoft.AspNetCore.Mvc;
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
