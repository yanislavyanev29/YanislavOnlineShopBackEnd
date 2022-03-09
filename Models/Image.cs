

namespace OnlineShop.DB.Models
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }


        public string RemoteImageUrl { get; set; }
    }
}
