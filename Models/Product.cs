
using System.ComponentModel.DataAnnotations;


namespace OnlineShop.DB.Models
{
    public class Product
    {

        public Product()
        {
            
            
           
        }
       
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }
        public string Type { get; set; }

        public string ImageUrl1 { get; set; }

        public string ImageUrl2 { get; set; }

        public string ImageUrl3 { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }

        public int CategoryId { get; set; }
        public  Category Category { get; set; }

      
    }
}
