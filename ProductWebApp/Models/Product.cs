using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductWebApp.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        //As per requirement max char limit is 100
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        [Required]
        [Range(0, 9999999.99)]
        public decimal Qty { get; set; }
    }
}
