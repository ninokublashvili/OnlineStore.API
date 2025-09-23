using OnlineStore.Domain.Entities.Base;
using OnlineStore.Domain.Entities.OrderItemAggregate;
using OnlineStore.Domain.Entities.ProductAggregate;
using OnlineStore.Domain.Entities.User;

namespace OnlineStore.Domain.Entities.OrderAggregate
{
    public enum OrderStatus { Pending = 0, Confirmed = 1, Rejected = 2, Cancelled = 3 }

    public class Order : BaseEntity<int>
    {
        public Order(string orderNumber, OrderStatus status,
                     DateTime createdAtUtc, DateTime? cancelledAtUtc,
                     int userId)
        {
            OrderNumber = orderNumber;
            Status = status;
            CreatedAtUtc = createdAtUtc;
            CancelledAtUtc = cancelledAtUtc;
            UserId = userId;
        }

        public string OrderNumber { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAtUtc { get; private set; }
        public DateTime? CancelledAtUtc { get; private set; }
        public int UserId { get; private set; }     
        public virtual Users User { get; private set; } 
        public virtual ICollection<OrderItem> Items { get; protected set; } = new List<OrderItem>();

        public decimal Total => Items.Sum(i => i.LineTotal);

        
        public static Order Create(string orderNumber, DateTime nowUtc,int userId)
        => new(orderNumber, OrderStatus.Pending, nowUtc, null,userId);

        public void AddItem(Product product, int quantity)
        {
            var existing = Items.FirstOrDefault(i => i.ProductId == product.Id && i.UnitPrice == product.Price);
            if (existing is null)
                Items.Add(OrderItem.Create(product.Id, product.Price, quantity));
            else
                existing.AddQuantity(quantity);
        }

        public void Cancel()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException("Only pending orders can be cancelled.");
            Status = OrderStatus.Cancelled;
        }
    }
}

