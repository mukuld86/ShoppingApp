using Microsoft.EntityFrameworkCore;
using ShoppingDAL.Models;

namespace ShoppingDAL
{
    public class ShoppingRepository:IShoppingRepository
    {
        private ShoppingContext context;
        public ShoppingRepository()
        {
            context = new ShoppingContext();
        }
        public bool Register(User entUser)
        {
            bool result = false;
            try
            {
                context.Users.Add(entUser);
                context.SaveChanges();
                result = true;
            }
            catch(Exception e)
            {
                throw e;
            }
            return result;
        }
        public User Login(string username, string password)
        {
            User user = null;
            try
            {
                user = context.Users.Where(u => u.UserId == username && u.Password == password).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }
        public User GetUserById(string userId)
        {
            User user = null;
            try
            {
                user = context.Users.Find(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }
        public bool UpdateProfile(User entUser)
        {
            bool flag = false;
            try
            {
                User user = context.Users.Find(entUser.UserId);
                user.Address = entUser.Address;
                user.Email = entUser.Email;
                user.Name = entUser.Name;
                user.Password = entUser.Password;
                context.SaveChanges();
                flag = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }
        public int ResetPassword(string userid, string oldPass, string newPass)
        {
            try
            {
                User user = context.Users.Find(userid);
                if (user != null && user.Password == oldPass)
                {
                    user.Password = newPass;
                    context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return -1;
        }
        public List<Product> SearchProducts(string searchTerm)
        {
            List<Product> products = null;
            try
            {
                products = context.Products.Where(p => p.ProductName.Contains(searchTerm)).Include(c => c.Category).ToList();
            }
            catch (Exception e)
            {
                throw e;

            }
            return products;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = null;
            try
            {
                products = context.Products.Include(c => c.Category).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return products;
        }
        public List<Product> GetProductByCategory(string category)
        {
            List<Product> products = null;
            try
            {
                products = context.Products.Where(p => p.Category.CategoryName == category).Include(c => c.Category).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return products;
        }
        public Product GetProductById(int id)
        {
            Product product = null;
            try
            {
                product = context.Products.Where(p => p.ProductId == id)
                    .Include(c => c.Category)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return product;
        }
        public bool AddProduct(Product product)
        {
            bool result = false;
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public bool RemoveProduct(int id)
        {
            bool result = false;
            try
            {
                Product product = context.Products.Where(p => p.ProductId == id).FirstOrDefault();
                context.Products.Remove(product);
                context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public bool UpdateProductDetails(Product entProd)
        {
            bool result = false;
            try {
                Product product = context.Products.Where(p => p.ProductId == entProd.ProductId).FirstOrDefault();
                product.ProductName = entProd.ProductName;
                product.ProductDescription = entProd.ProductDescription;
                product.UnitPrice = entProd.UnitPrice;
                context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = null;
            try
            {
                categories = context.Categories.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return categories;
        }
        public Category GetCategoryById(int id)
        {
            Category category = null;
            try
            {
                category = context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
            return category;
        }
        public bool AddCategory(Category category)
        {
            bool result = false;
            try
            {
                context.Categories.Add(category);
                context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public bool RemoveCategory(int id)
        {
            bool result = false;
            try
            {
                Category category = context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
                context.Categories.Remove(category);
                context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        public bool UpdateCategoryName(int id, string newName)
        {
            bool result = false;
            try
            {
                Category category = context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
                category.CategoryName = newName;
                context.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public int PlaceOrder(Order order)
        {
            try
            {
                context.Orders.Add(order);
                for (int i = 0; i < order.Items.Count; i++)
                {
                    order.Items[i].OrderId = order.OrderId;
                    context.OrderItems.Add(order.Items[i]);
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return order.OrderId;
        }
    }
}
