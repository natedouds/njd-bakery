using System.ComponentModel.DataAnnotations.Schema;

namespace Njd.Bakery.Repository.EfModels
{
    public class ProductCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
