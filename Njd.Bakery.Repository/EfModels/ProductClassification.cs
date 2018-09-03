using System.ComponentModel.DataAnnotations.Schema;

namespace Njd.Bakery.Repository.EfModels
{
    public class ProductClassification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
