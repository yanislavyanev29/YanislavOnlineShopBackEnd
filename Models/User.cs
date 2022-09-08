
using Microsoft.AspNetCore.Identity;
using YanislavOnlineShopBackEnd.Models;

namespace OnlineShop.DB.Models
{
    public class User : IdentityUser<int>
    {

        public UserAddress Address { get; set; }

    }
}
