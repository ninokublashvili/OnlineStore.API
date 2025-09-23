using OnlineStore.Domain.Entities.Base;
using OnlineStore.Domain.Entities.OrderAggregate;
using OnlineStore.Domain.Entities.ProductAggregate;

namespace OnlineStore.Domain.Entities.OrderItemAggregate
{
    public class OrderItem : BaseEntity<int>
    {
        public OrderItem(int orderId,int productId,
                         decimal unitPrice, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public int OrderId { get; private set; }
        public virtual Order Order { get; private set; } 
        public int ProductId { get; private set; }
        public virtual Product Product { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        public decimal LineTotal => UnitPrice * Quantity;

        public static OrderItem Create(int productId, decimal unitPrice, int quantity)
        => new(0, productId, unitPrice, quantity); 

        internal void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}

