using YanislavOnlineShopBackEnd.Models;

namespace YanislavOnlineShopBackEnd.DTO
{
    public class CreateOrderDto
    {

        public bool SaveAddress { get; set; }

        public ShippingAddress ShippingAddress { get; set; }
    }
}
