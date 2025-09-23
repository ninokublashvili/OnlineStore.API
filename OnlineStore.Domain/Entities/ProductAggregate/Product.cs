using OnlineStore.Domain.Entities.Base;

namespace OnlineStore.Domain.Entities.ProductAggregate
{
    public class Product : BaseEntity<int>
    {
        public Product(string name, string sku, decimal price, int stockQuantity)
        {
            Name = name;
            Sku = sku;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public string Name { get; private set; }
        public string Sku { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

        public static Product Create(string name, string sku, decimal price, int stock)
            => new(name, sku, price, stock);

        public void Update(string sku, decimal price, int stock, bool isActive)
        {
            Sku = sku.Trim();
            Price = price;
            StockQuantity = stock;
            IsActive = isActive;
        }

        public bool TryReserveStock(int quantity)
        {
            if (quantity <= 0) return false;
            if (!IsActive) return false;
            if (StockQuantity < quantity) return false;

            StockQuantity -= quantity;
            return true;
        }
    }
}