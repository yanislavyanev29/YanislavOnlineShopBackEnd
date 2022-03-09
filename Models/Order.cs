using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DB.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string UserAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
