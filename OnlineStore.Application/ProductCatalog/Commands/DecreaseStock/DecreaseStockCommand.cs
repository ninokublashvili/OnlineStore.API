using MediatR;

namespace OnlineStore.Application.ProductCatalog.Commands.DecreaseStock
{
    public class DecreaseStockCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
    }
}
