using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PurchasePrice { get; set; }
        public float SellingPrice { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public int ShippingId { get; set; }
        public int CategoryId { get; set; }
    }
}