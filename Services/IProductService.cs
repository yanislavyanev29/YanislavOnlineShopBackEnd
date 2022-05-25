using OnlineShop.DB.Models;

namespace YanislavOnlineShopBackEnd.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(int id);

        

    }
}
