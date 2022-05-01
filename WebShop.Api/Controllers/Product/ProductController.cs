using System.Threading.Tasks;
using AutoMapper;
using CQRS.Commands.Product;
using CQRS.Handlers.Product.CommandHandlers;
using CQRS.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebShopApi.Controllers.Product.Requests;
using WebShopDomain.Models;

namespace WebShopApi.Controllers.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequest request)
        {
            var mapped = _mapper.Map<ProductDto>(request);
            await _mediator.Send(new AddProductCommand(mapped));
            return Ok();
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest request)
        {
            var mapped = _mapper.Map<ProductDto>(request);
            var result = await _mediator.Send(new UpdateProductCommand(id, mapped));
            return Ok(result);
        }
        
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }
    }
}