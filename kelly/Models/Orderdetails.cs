using System.ComponentModel.DataAnnotations;

namespace kelly.Models
{
    public class OrderDetails
    {

        //

        public int OrderDetailsID { get; set; }
        [Required]
        //changed to display the heading as order name
        [Display(Name ="Order name")]
        public int OrdersID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Required]
        public int Qty { get; set; }
        public Orders Orders { get; set; }
        public Product Product { get; set; }
    }
}
