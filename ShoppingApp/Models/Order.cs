namespace ShoppingApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderedDate { get; set; }
        public User User { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public float OrderCost { get; set; }
    }
}