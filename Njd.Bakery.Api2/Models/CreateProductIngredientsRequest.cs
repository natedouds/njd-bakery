using System.Collections.Generic;

namespace Njd.Bakery.Api.Models
{
    public class CreateProductIngredientsRequest
    {
        public string ProductId { get; set; }
        public IEnumerable<int> IngredientIds { get; set; }
    }
}
