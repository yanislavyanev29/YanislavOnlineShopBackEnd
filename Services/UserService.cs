using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using YanislavOnlineShopBackEnd.CustomExceptions;
using YanislavOnlineShopBackEnd.DTO;
using YanislavOnlineShopBackEnd.Utilities;

namespace YanislavOnlineShopBackEnd.Services
{
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        public UserService(ApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            this._context = context;
            this._passwordHasher = passwordHasher;
        }

        public  async Task<AuthenticatedUser> SignIn(User user)
        {
            var dbUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username);

            if (dbUser == null || dbUser.Password == null
                || _passwordHasher.VerifyHashedPassword(dbUser.Password, user.Password) == Microsoft.AspNet.Identity.PasswordVerificationResult.Failed)
            {
                throw new InvalidUsernameOrPasswordException("Invalid username or password");

            }

            return new AuthenticatedUser()
            {
                Username = user.Username,
                Token = JwtGenerator.GenerateAuthToken(user.Username),
            };
}

        public async  Task<AuthenticatedUser> SignUp(User user)
        {
            var checkUsername = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.Equals(user.Username));

            if (checkUsername != null)
            {
                throw new UsernameAlreadyExists("Username already exists");
            }

            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = _passwordHasher.HashPassword(user.Password);
            }

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return new AuthenticatedUser
            {
                Username = user.Username,
                Token = JwtGenerator.GenerateAuthToken(user.Username),
            };
        }
    }
}
