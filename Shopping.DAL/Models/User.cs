namespace ShoppingDAL.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int UserRoleId { get; set; }
        public Role UserRole { get; set; }
    }
}
