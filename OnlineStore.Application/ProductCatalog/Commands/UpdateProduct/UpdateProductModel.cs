namespace OnlineStore.Application.ProductCatalog.Commands.UpdateProduct
{
    public class UpdateProductModel
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}
