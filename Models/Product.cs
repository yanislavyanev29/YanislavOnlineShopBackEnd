
using System.ComponentModel.DataAnnotations;


namespace OnlineShop.DB.Models
{
    public class Product
    {

        public Product()

        {
            this.Sizes = new HashSet<Size>();
            this.Votes = new List<Vote>();
            this.Images = new HashSet<Image>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }


        public virtual ICollection<Size> Sizes { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
