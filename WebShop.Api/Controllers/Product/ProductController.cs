using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CQRS.Commands.Product;
using CQRS.Handlers.Product.CommandHandlers;
using CQRS.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebShopApi.Controllers.Product.Requests;
using WebShopApi.Controllers.Product.Responses;
using WebShopDomain.Models;

namespace WebShopApi.Controllers.Product
{
    [ApiController]
    [Route("api/")]
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
        [Route("[controller]")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            var output = _mapper.Map<IEnumerable<ProductDto>, List<ProductResponse>>(result);
            return Ok(output);
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            var output = _mapper.Map<ProductResponse>(result);
            return Ok(output);
        }
        
        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductRequest request)
        {
            var mapped = _mapper.Map<ProductDto>(request);
            await _mediator.Send(new AddProductCommand(mapped));
            return Ok();
        }
        
        [HttpPut]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest request)
        {
            var mapped = _mapper.Map<ProductDto>(request);
            var result = await _mediator.Send(new UpdateProductCommand(id, mapped));
            var output = _mapper.Map<ProductResponse>(result);
            return Ok(output);
        }
        
        
        [HttpDelete]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }
    }
}