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
        public int ResetPassword(string userid, string oldPass, string newPass);

        // product
        public List<Product> SearchProducts(string searchTerm);
        public List<Product> GetProducts();
        public List<Product> GetProductByCategory(string category);
        public Product GetProductById(int id);
        public bool AddProduct(Product product);
        public bool RemoveProduct(int id);
        public bool UpdateProductDetails(Product entProd);

        // category
        public List<Category> GetCategories();
        public Category GetCategoryById(int id);
        public bool AddCategory(Category category);
        public bool RemoveCategory(int id);
        public bool UpdateCategoryName(int id, string newName);

        // order
        public int PlaceOrder(Order order);
    }
}
