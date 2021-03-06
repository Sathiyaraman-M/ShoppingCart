using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public sealed class Product
    {
        public long ProductId { get; set; }
        [Required(ErrorMessage = "Please enter a Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid Product Description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter the stock quantity available")]
        public int StockQuantity { get; set; }
    }
}