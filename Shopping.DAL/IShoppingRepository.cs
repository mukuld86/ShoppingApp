using ShoppingDAL.Models;

namespace ShoppingDAL
{
    public interface IShoppingRepository
    {
        // user
        public bool Register(User entUser);
        public User Login(string username, string password);
        public User GetUserById(string userId);
        public bool UpdateProfile(User entUser);

        // product
        public List<Product> SearchProducts(string searchTerm);
        public List<Product> GetProducts();

    }
}
