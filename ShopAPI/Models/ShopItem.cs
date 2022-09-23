using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models
{
    public class ShopItem
    {
        [Required]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Range(typeof(Decimal), "1", "9999", ErrorMessage = "{0} must be a decimal/number between {1} and {2}.")]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
