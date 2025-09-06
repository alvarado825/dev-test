using Application.Client.Commands.CreateClient;
using Application.Client.Queries.AllClientsQuery;
using Application.Client.Queries.ClientByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Client.Queries.ClientByDocumentNumberQuery;
using Domain.Utils;
using Application.Client.Commands.UpdateClient;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateClientCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{documentNumber}")]
        public async Task<IActionResult> UpdateClient([FromRoute] string documentNumber, [FromBody] UpdateClientCommandRequest request)
        {
            request.Identificator = documentNumber;

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientByIdQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new ClientByIdQueryRequest { Id = id });

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ClientByDocumentNumberQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<AllClientsQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClient([FromQuery] string documentNumber = null)
        {

            if (!string.IsNullOrEmpty(documentNumber))
            {
                var response = await _mediator.Send(new ClientByDocumentNumberQueryRequest { DocumentNumber = documentNumber });
                return Ok(response);
            }

            var listResponse = await _mediator.Send(new AllClientsQueryRequest());
            return Ok(listResponse);
        }
    }
}
