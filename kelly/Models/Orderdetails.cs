using System.ComponentModel.DataAnnotations;

namespace kelly.Models
{
    public class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        [Required]
        public int OrdersID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Qty { get; set; }
        public Orders Orders { get; set; }
        public Product Product { get; set; }
    }
}
