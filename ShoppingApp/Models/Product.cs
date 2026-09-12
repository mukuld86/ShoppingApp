using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsAvailable { get; set; }
        public Category Category { get; set; }
    }
}