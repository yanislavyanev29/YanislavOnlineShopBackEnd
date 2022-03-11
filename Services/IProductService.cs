using OnlineShop.DB.Models;

namespace YanislavOnlineShopBackEnd.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(int id);

        Product CreateProduct(Product product);

       Product UpdateProduct(Product data);

        void DeleteProduct(Product product);

    }
}
