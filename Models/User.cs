
using System.ComponentModel.DataAnnotations;


namespace OnlineShop.DB.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Votes = new List<Vote>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MaxLength(6)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string ExternalId { get; set; }
        public string ExternalType { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
