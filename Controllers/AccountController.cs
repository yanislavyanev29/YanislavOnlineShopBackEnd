﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using YanislavOnlineShopBackEnd.DTO;
using YanislavOnlineShopBackEnd.Extensions;
using YanislavOnlineShopBackEnd.Models;
using YanislavOnlineShopBackEnd.Services;

namespace YanislavOnlineShopBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<User> userManager , TokenService tokenService,ApplicationDbContext context)
        {
             _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
        }


        [Authorize]
        [HttpGet("savedAddress")]
        public async Task<ActionResult<UserAddress>> GetSavedAddress()
        {

            return await _userManager.Users
                .Where(x => x.UserName == User.Identity.Name)
                .Select(user => user.Address)
                .FirstOrDefaultAsync();
        }

        [HttpPost("login")]
       public async Task<ActionResult<UserDTO>> Login (LoginDTO loginDTO)
        {

            var user = await _userManager.FindByNameAsync(loginDTO.Username);

            if(user == null || !await _userManager.CheckPasswordAsync(user,loginDTO.Password))
            {
                return Unauthorized();
            }

            var userBasket = await RetrieveBasket(loginDTO.Username);
            var anonBasket = await RetrieveBasket(Request.Cookies["buyerId"]);

            if(anonBasket != null)
            {

                if(userBasket != null)  _context.Baskets.Remove(userBasket);


                    anonBasket.BuyerId = user.UserName;
                    Response.Cookies.Delete("buyerId");
                    await _context.SaveChangesAsync();
                

               
            }

            return new UserDTO
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user),
                Basket = anonBasket != null ? anonBasket.MapBasketToDto() : userBasket?.MapBasketToDto(),
            };
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO registerDTO)
        {

            var user = new User { UserName = registerDTO.Username, Email = registerDTO.Email };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();

            }

            await _userManager.AddToRoleAsync(user, "Member");

            return StatusCode(201);

        }

        [Authorize]
        [HttpGet("currentUser")]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var userBasket = await RetrieveBasket(User.Identity.Name);

            return new UserDTO
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user),
                Basket = userBasket?.MapBasketToDto()
            };
        }

        

        private async  Task<Basket> RetrieveBasket(string buyerId)
        {
            if (string.IsNullOrEmpty(buyerId))
            {
                Response.Cookies.Delete("buyerId");
                return null;
            }

            return await _context.Baskets
                .Include(i => i.Items)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(x => x.BuyerId == buyerId);

        }

    }
}
