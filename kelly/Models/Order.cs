namespace kelly.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime PickupTime { get; set; }
    }
}
