namespace WebUI.ViewModels
{
    public class ProductModelForListProducts
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string CargoCompanyName { get; set; }
        public string CategoryName { get; set; }
    }
}
