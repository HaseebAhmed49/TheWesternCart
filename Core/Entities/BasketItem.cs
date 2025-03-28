using Core.Common;

namespace Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public string ClothingName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string Brand { get; set; }
        public decimal? Discount { get; set; }
    }
}