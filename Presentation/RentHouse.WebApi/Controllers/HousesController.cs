﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Common.Sort;
using RentHouse.Application.Features.CQRS.HouseFeatures.Queries.GetByHouseId;
using RentHouse.Application.Features.CQRS.HouseImages.Queries.GetByHouse;
using RentHouse.Application.Features.CQRS.Houses.Commands.Create;
using RentHouse.Application.Features.CQRS.Houses.Commands.Remove;
using RentHouse.Application.Features.CQRS.Houses.Commands.Update;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetById;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetList;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetListWithLocationByDate;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetWithFeaturesById;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetWithLocationById;
using RentHouse.Application.Features.CQRS.Reservations.Queries.GetLisyByHouseId;
using RentHouse.Application.Features.Filters.Houses;


namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "RentHouse")]
    [ApiController]
    public class HousesController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] PaginationQuery paginationQuery,
            [FromQuery] SortingQuery sortQuery,
            [FromQuery] HouseFilterByDateDto houseFilter)
        {


            var result = await Mediator.Send(new GetListHouseQuery(paginationQuery, sortQuery, houseFilter));
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await Mediator.Send(new GetByIdHouseQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHouseCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateHouseCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await Mediator.Send(new RemoveHouseCommand(id));
            return Ok();
        }
        [AllowAnonymous]
        [HttpGet("with-location")]
        public async Task<IActionResult> GetWithLocationByFilter(
            [FromQuery] PaginationQuery paginationQuery,
            [FromQuery] SortingQuery sortQuery,
            [FromQuery] HouseFilterByDateDto houseFilter)
        {
            var result = await Mediator.Send(new GetHouseWithLocationByDateQuery(paginationQuery, sortQuery, houseFilter));
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("{id}/with-location")]
        public async Task<IActionResult> GetWithLocation(int id)
        {
            var value = await Mediator.Send(new GetHouseWithLocationByIdQuery(id));
            return Ok(value);
        }

        [AllowAnonymous]
        [HttpGet("{id}/Reservations")]
        public async Task<IActionResult> GetReservations(int id, [FromQuery] PaginationQuery paginationQuery)
        {
            var values = await Mediator.Send(new GetReservationsByHouseIdQuery(id, paginationQuery));
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("{id}/Features")]
        public async Task<IActionResult> GetFeatures(int id)
        {
            var values = await Mediator.Send(new GetHouseFeatureByHouseIdQuery(id));
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("{id}/with-features")]
        public async Task<IActionResult> GetWithFeatures(int id)
        {
            var value = await Mediator.Send(new GetHouseWithFeaturesByIdQuery(id));
            return Ok(value);
        }
        [AllowAnonymous]
        [HttpPost("with-features")]
        public async Task<IActionResult> CreateWithFeatures(CreateHouseWithFeaturesCommand createHouseWithFeaturesCommand)
        {
            await Mediator.Send(createHouseWithFeaturesCommand);
            return Ok();
        }

        [HttpPut("with-features")]
        public async Task<IActionResult> UpdateWithFeatures(UpdateHouseWithFeaturesCommand updateHouseWithFeaturesCommand)
        {
            await Mediator.Send(updateHouseWithFeaturesCommand);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{id}/HouseImages")]
        public async Task<IActionResult> GetHouseImages(int id)
        {
            var values = await Mediator.Send(new GetHouseImagesByHouseQuery(id));
            return Ok(values);
        }

    }
}
