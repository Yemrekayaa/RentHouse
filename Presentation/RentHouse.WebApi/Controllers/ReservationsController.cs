using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Features.CQRS.Reservations.Commands.Create;
using RentHouse.Application.Features.CQRS.Reservations.Commands.Remove;
using RentHouse.Application.Features.CQRS.Reservations.Commands.Update;
using RentHouse.Application.Features.CQRS.Reservations.Queries.GetById;
using RentHouse.Application.Features.CQRS.Reservations.Queries.GetByIdWithHouse;
using RentHouse.Application.Features.CQRS.Reservations.Queries.GetListWithHouse;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "RentHouse")]
    [ApiController]
    public class ReservationsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PaginationQuery paginationQuery)
        {
            var values = await Mediator.Send(new GetReservationListWithHouseQuery(paginationQuery));
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdReservationQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateReservationCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await Mediator.Send(new RemoveReservationCommand(id));
            return Ok();
        }

        [HttpGet("{id}/with-house")]
        public async Task<IActionResult> GetByIdWithHouse(int id)
        {
            var value = await Mediator.Send(new GetReservationByIdWithHouseQuery(id));
            return Ok(value);
        }
        [HttpGet("with-house")]
        public async Task<IActionResult> GetByIdWithHouse([FromQuery] PaginationQuery paginationQuery)
        {
            var values = await Mediator.Send(new GetReservationListWithHouseQuery(paginationQuery));
            return Ok(values);
        }
    }
}
