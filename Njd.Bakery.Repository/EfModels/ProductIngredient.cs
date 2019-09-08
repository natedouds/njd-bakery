namespace Njd.Bakery.Repository.EfModels
{
    public class ProductIngredient
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
