using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Njd.Bakery.Repository.EfModels
{
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();
    }
}
