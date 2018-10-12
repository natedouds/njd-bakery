using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Njd.Bakery.Repository.EfModels
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ParentProductId { get; set; }
        public string Name { get; set; }
        // this would probably be the unique public facing identifier
        public string Sku { get; set; }
        // the goal here is that default will be the highest level, but it can have nested alternates for allergies
        public bool IsDefaultProduct { get; set; }
        public bool GlutenFree { get; set; }
        public bool CanBeGlutenFree { get; set; }
        public bool GrainFree { get; set; }
        public bool CanBeGrainFree { get; set; }
        public bool DairyFree { get; set; }
        public bool CanBeDairyFree { get; set; }
        public bool EggFree { get; set; }
        public bool CanBeEggFree { get; set; }
        public bool RefinedSugarFree { get; set; }
        public bool CanBeRefinedSugarFree { get; set; }
        public bool NutFree { get; set; }
        public bool CanBeNutFree { get; set; }
        public bool Vegan { get; set; }
        public bool CanBeVegan { get; set; }
        public int DefaultNumberOfServings { get; set; }
        public decimal TotalBatchCalories { get; set; }
        public decimal TotalBatchFat { get; set; }
        public decimal TotalBatchCarbs { get; set; }
        public decimal TotalBatchFiber { get; set; }
        public decimal TotalBatchSugar { get; set; }
        public decimal TotalBatchProtein { get; set; }

        public ProductCategory Category { get; set; }
        public ProductClassification Classification { get; set; }
        public IEnumerable<Product> ProductVariations { get; set; }
        public IEnumerable<ProductIngredient> ProductIngredients { get; set; }
    }
}
