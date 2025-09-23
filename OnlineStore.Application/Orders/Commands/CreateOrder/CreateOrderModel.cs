namespace OnlineStore.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderModel
    {
        public List<CreateOrderItem> Items { get; set; } = new();

        public class CreateOrderItem
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}

