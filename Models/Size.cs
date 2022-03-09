
using System.ComponentModel.DataAnnotations;


namespace OnlineShop.DB.Models
{
    public class Size
    {
        public int Id { get; set; }
        [MaxLength(4)]
        public string value { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
