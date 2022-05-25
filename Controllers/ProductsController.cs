using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using YanislavOnlineShopBackEnd.Services;

namespace YanislavOnlineShopBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(this._productService.GetProducts());
        }

        [HttpGet("{Id}", Name = "GetProduct")]
        public IActionResult GetProduct(int Id)
        {

            return Ok(this._productService.GetProduct(Id));
        }

       
           
    }
}
