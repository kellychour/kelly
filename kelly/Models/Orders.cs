using kelly.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace kelly.Models
{
    public class Orders

    {
        [Display(Name = "OrderID")]
        public int OrdersID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]

        [Display(Name = "Order date")]
        public DateTime? OrderTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Pickup time")]
        public DateTime? PickupTime { get; set; }
        [Display(Name = "Status")]
        public string OrderStatus { get; set; } //drop down options for status of orders
        
        public kellyUser kellyUser { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        




    }
}
