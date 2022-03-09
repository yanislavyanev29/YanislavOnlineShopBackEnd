

namespace OnlineShop.DB.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }


        public byte Value { get; set; }
    }
}
