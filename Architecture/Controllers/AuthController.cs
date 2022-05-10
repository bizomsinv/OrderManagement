using Microsoft.AspNetCore.Mvc;
using MediatR;
using Model.Routes;
using System.Net.Mime;
using Domain.Queries;
using Model.Factory;
using Model.Response;
using Model.Request;
using Domain.Commands;
using Entity.Entities;

namespace Architecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly IMediator _mediator;
        public AuthController(ILogger<SupplierController> logger,
            IMediator mediator,
            ISupplierFactory supplierFactory)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(AuthenticateRoutes.Auth)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> GetAllSuppliers([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var query = new AuthenticateUserQuery(request.UserName, request.Password);

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(AuthenticateRoutes.AddUser)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> AddUser([FromBody] AddUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new AddUserCommand(request.Name,
                request.UserName,
                request.Password);

            (User user, string message) = await _mediator.Send(command);

            return Ok(message);
        }
    }
}
