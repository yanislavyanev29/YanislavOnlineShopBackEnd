﻿using OnlineShop.DB.Models;

namespace YanislavOnlineShopBackEnd.Extensions
{
    public  static class ProductExtensions
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query, string orderBy)
        {
            if(string.IsNullOrEmpty(orderBy)) return query.OrderBy(p => p.Name);

            query = orderBy switch
            {

                "clothes" => query.Where(x => x.CategoryId == 1),
                "shoes" => query.Where(x => x.CategoryId == 2),
                "accessories" => query.Where(x => x.CategoryId == 3),
                _ => query.OrderBy(p => p.Name),
            };


            return query;
        }

        public static IQueryable<Product> Search(this IQueryable<Product> query, string searchTerm)
        {

            if (string.IsNullOrEmpty(searchTerm)) return query;

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            return query.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<Product> Filter (this IQueryable<Product> query, string brands,string types)
        {

            var brandList = new List<string>();
            var typeList = new List<string>();

            if (!string.IsNullOrEmpty(brands))
            {
                brandList.AddRange(brands.ToLower().Split(",").ToList());
            }

            if (!string.IsNullOrEmpty(types))
            {
                typeList.AddRange(types.ToLower().Split(",").ToList());
            }

            query = query.Where(p => brandList.Count == 0 || 
            brandList.Contains(p.Brand.ToLower()));

            query = query.Where(p => typeList.Count == 0 ||
            typeList.Contains(p.Type.ToLower()));
            return query;
        }
    }
}
