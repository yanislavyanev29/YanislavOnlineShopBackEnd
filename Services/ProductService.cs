using OnlineShop.DB;
using OnlineShop.DB.Models;

namespace YanislavOnlineShopBackEnd.Services
{
    public class ProductService : IProductService
    {

        private ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context )
        {
            this._context = context;
        }

        public Product CreateProduct(Product product)
        {
            _context.Add( product );
            _context.SaveChanges();

            return (Product)product;
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove( product );
            _context.SaveChanges();
        }

        public Product GetProduct(int id)
        {
           return _context.Products.First(p => p.Id == id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var productToEdit = _context.Products.FirstOrDefault(e => e.Id == product.Id);
            if(productToEdit != null)
            {
                productToEdit.Name = product.Name;
                productToEdit.Description = product.Description;
                productToEdit.IsAvailable= product.IsAvailable;
                productToEdit.Price = product.Price;
                productToEdit.CategoryId=product.CategoryId;

                _context.SaveChanges();
            }
            return productToEdit;
        }
    }
}
