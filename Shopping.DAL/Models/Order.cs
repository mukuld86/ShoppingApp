using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingDAL.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderedDate { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]    
        public string UserId { get; set; }
        public List<OrderItem> Items { get; set; }
        public double OrderCost { get; set; }
    }
}
