using Microsoft.AspNetCore.Mvc;
using MediatR;
using Model.Routes;
using System.Net.Mime;
using Domain.Queries;
using Model.Factory;
using Model.Response;
using Model.Request;
using Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Architecture.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly IMediator _mediator;
        private readonly ISupplierFactory _supplierFactory;
        public SupplierController(ILogger<SupplierController> logger,
            IMediator mediator,
            ISupplierFactory supplierFactory)
        {
            _logger = logger;
            _mediator = mediator;
            this._supplierFactory = supplierFactory;
        }

        /// <summary>
        /// Get all suppliers
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet(SupplierRoutes.GetAll)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<SupplierResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<SupplierResponse>>> GetAllSuppliers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var query = new GetAllSuppliersQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        /// <summary>
        /// Get Supplier By Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet(SupplierRoutes.Get)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(SupplierResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SupplierResponse>> GetAllSuppliers([FromRoute(Name = "id")] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var query = new GetSupplierByIdQuery(id);

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        /// <summary>
        /// Create new Supplier
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(SupplierRoutes.Add)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> CreateSupplier([FromBody] SupplierRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new AddSupplierCommand(request.SupplierName,
                request.AddressLine1,
                request.AddressLine2,
                request.PostalCodel,
                request.City,
                request.State);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        /// <summary>
        /// Update Supplier
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut(SupplierRoutes.Edit)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> UpdateSupplier([FromBody] SupplierRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdateSupplierCommand(request.SupplierName,
                request.AddressLine1,
                request.AddressLine2,
                request.PostalCodel,
                request.City,
                request.State,
                request.SupplierId);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        /// <summary>
        /// Delete Supplier
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete(SupplierRoutes.Delete)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> DeleteSupplier([FromRoute(Name = "id")] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new DeleteSupplierCommand(id);

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
