using System.ComponentModel.DataAnnotations;

namespace SampleShoppingApplication.Data
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
