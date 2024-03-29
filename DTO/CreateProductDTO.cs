﻿using OnlineShop.DB.Models;
using System.ComponentModel.DataAnnotations;

namespace YanislavOnlineShopBackEnd.DTO
{
    public class CreateProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(100, Double.PositiveInfinity)]
        public decimal Price { get; set; }

        [Required]
        public IFormFile File  { get; set; }


        [Required]
        public string Brand { get; set; }

        [Required]
        [Range(0, 200)]
        public int QuantityInStock { get; set; }

        
        public Category? Category { get; set; }
    }
}
