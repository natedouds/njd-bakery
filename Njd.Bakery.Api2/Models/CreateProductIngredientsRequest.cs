using System.Collections.Generic;

namespace Njd.Bakery.Api.Controllers.Models
{
    public class CreateProductIngredientsRequest
    {
        public int ProductId { get; set; }
        public IEnumerable<int> IngredientIds { get; set; }
    }
}
