using OnlineShop.DB.Models;
using YanislavOnlineShopBackEnd.DTO;

namespace YanislavOnlineShopBackEnd.Services
{
    public interface IUserService
    {
        Task<AuthenticatedUser> SignUp(User user);
        Task<AuthenticatedUser> SignIn(User user);


    }
}
