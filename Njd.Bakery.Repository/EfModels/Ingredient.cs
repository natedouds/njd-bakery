using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Njd.Bakery.Repository.EfModels
{
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ProductIngredient> ProductIngredients { get; set; } = Enumerable.Empty<ProductIngredient>();
    }
}
