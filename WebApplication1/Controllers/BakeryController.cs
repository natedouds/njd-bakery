using Microsoft.AspNetCore.Mvc;
using Njd.Bakery.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Njd.Bakery.Api.Controllers
{
    [Route("api/[controller]")]
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
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/products/categories
        [HttpGet("categories")]
        public ActionResult<IEnumerable<string>> GetProductCategories()
        {
            return Ok(_context.ProductCategories.ToList());
        }

    }
}
