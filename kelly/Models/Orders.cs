using kelly.Areas.Identity.Data;
using kelly.Migrations;
using System.ComponentModel.DataAnnotations;

namespace kelly.Models
{
    public class Orders

    {
        [Display(Name = "OrderID")]
        public int OrdersID { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-mmm-yyyy hh:mm", ApplyFormatInEditMode = true)]
        [Display(Name = "Order date")]
        public DateTime OrderTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-mmm-yyyy hh:mm}", ApplyFormatInEditMode = true)]//probaby change it to a drop down list
        [Display(Name = "Pickup time")]
        public DateTime? PickupTime { get; set; }
        [Display(Name = "Status")]
        public string OrderStatus { get; set; }

        public kellyUser kellyUser { get; set; }
        //public OrderDetails OrderDetails { get; set; }




    }
}
