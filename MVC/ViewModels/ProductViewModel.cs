namespace MVC.ViewModels
{
    public class ProductViewModel
    {
        public List<string> ProductNames { get; set; }
        public List<decimal> PurchasePrices { get; set; }
        public List<decimal> SalePrices { get; set; }
        public List<string> Descriptions { get; set; }
        public List<int> Stocks { get; set; }
        public List<short> CargoCompanyIds { get; set; }
        public List<short> CategoryIds { get; set; }
    }
}
