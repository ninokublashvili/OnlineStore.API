namespace OnlineStore.Application.ProductCatalog.Commands.CreateProduct
{
    public class CreateProductModel
    {
        public string Name { get; set; } 
        public string SKU { get; set; } 
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
