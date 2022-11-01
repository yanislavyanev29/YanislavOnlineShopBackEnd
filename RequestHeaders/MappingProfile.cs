using AutoMapper;
using OnlineShop.DB.Models;
using YanislavOnlineShopBackEnd.DTO;

namespace YanislavOnlineShopBackEnd.RequestHeaders
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

             CreateMap<CreateProductDTO, Product>();
             CreateMap<UpdateProductDTO, Product>();


           
        }
    }
}
