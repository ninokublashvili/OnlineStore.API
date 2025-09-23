using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.ProductCatalog.Commands.CreateProduct;
using OnlineStore.Application.ProductCatalog.Commands.DecreaseStock;
using OnlineStore.Application.ProductCatalog.Commands.UpdateProduct;
using OnlineStore.Application.ProductCatalog.Queries.GetProductById;
using OnlineStore.Application.ProductCatalog.Queries.GetProducts;
using OnlineStore.Application.Shared.Base;

namespace OnlineStore.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatalogController : BaseController
    {
        public ProductCatalogController(IMapper mapper, IMediator mediator)
                                       : base(mapper, mediator)
        {
        }

        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), 200)]
        [HttpPost(Name = nameof(CreateProduct))]
        public async Task CreateProduct([FromBody] CreateProductModel request) =>
           await _mediator.Send(_mapper.Map<CreateProductCommand>(request));

        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}", Name = nameof(UpdateProduct))]
        public async Task UpdateProduct([FromRoute] int id, [FromBody] UpdateProductModel request) =>
          await _mediator.Send(new UpdateProductCommand
          {
              Id = id,
              SKU = request.SKU,
              Price = request.Price,
              StockQuantity = request.StockQuantity,
              IsActive = request.IsActive
          });

        [Authorize(Roles = "User")]
        [HttpPut("{id:int}/stock/decrease")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DecreaseStock([FromRoute] int id, [FromBody] DecreaseStockCommand cmd, CancellationToken cancellationToken)
        {
            cmd.Id = id;
            await _mediator.Send(cmd, cancellationToken);
            return new NoContentResult();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetProduct))]
        public async Task<PagedList<ProductsModel>> GetProduct([FromQuery] GetProductsQueryModel query, CancellationToken cancellationToken) =>
           await _mediator.Send(_mapper.Map<GetProductsQuery>(query), cancellationToken);

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}", Name = nameof(GetProductById))]
        public async Task<ProductByIdModel> GetProductById([FromRoute] int id) =>
           await _mediator.Send(new GetProductByIdQuery { Id = id });


    }
}
