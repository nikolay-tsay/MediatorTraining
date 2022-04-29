using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CQRS.Commands.Client;
using CQRS.Queries.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebShopApi.Controllers.Client.Requests;
using WebShopApi.Controllers.Client.Responses;
using WebShopDomain.Models;

namespace WebShopApi.Controllers.Client
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public ClientController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var result = await _mediator.Send(new GetClientsQuery());
            var output = _mapper.Map<IEnumerable<ClientDto>, List<ClientResponse>>(result);
            return output.Any() 
                ? Ok(result) 
                : NoContent();
        }
        
        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var result = await _mediator.Send(new GetClientByIdQuery(id));
            var output = _mapper.Map<ClientResponse>(result);
            return Ok(output);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] CreateClientRequest request)
        {
            var mapped = _mapper.Map<ClientDto>(request);
            await _mediator.Send(new AddClientCommand(mapped));
            return Ok();
        }
        
        [HttpPut]
        [Route("/{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientRequest request)
        {
            var mapped = _mapper.Map<ClientDto>(request);
            var result = await _mediator.Send(new UpdateClientCommand(id, mapped));
            var output = _mapper.Map<ClientResponse>(result);
            return Ok(output);
        }
        
        
        [HttpDelete]
        [Route("/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _mediator.Send(new DeleteClientCommand(id));
            return Ok();
        }
    }
}