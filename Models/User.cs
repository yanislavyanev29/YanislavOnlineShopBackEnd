
using System.ComponentModel.DataAnnotations;


namespace OnlineShop.DB.Models
{
    public class User
    {
        public User()
        {
           
            
            this.OrderProducts = new List<OrderProduct>();
        }

        [Key]
        public int   Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
       
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? Address { get; set; }


        public string ExternalId { get; set; }
        public string ExternalType { get; set; }

       

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
