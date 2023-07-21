using System.ComponentModel.DataAnnotations;

namespace kelly.Models
{
    public class Orderdetails
    {

        public int OrderdetailsID { get; set; }
        public string? customerName { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
