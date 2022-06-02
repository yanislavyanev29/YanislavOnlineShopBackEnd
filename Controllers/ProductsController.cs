using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using YanislavOnlineShopBackEnd.Services;

namespace YanislavOnlineShopBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public  ActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("{id}")]
        public  ActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);

            if(product == null) return NotFound();

            return Ok(product);

        }
    }
}
