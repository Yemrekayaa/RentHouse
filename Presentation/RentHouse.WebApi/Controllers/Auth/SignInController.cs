using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse.Application.Features.CQRS.AppUsers.Queries;
using RentHouse.Application.Tools;

namespace RentHouse.WebApi.Controllers.Auth
{

    [Area("Auth")]
    [ApiExplorerSettings(GroupName = "Auth")]
    [ApiController]
    [Route("api/[area]/[controller]")]
    public class SignInController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(GetCheckAppUserQuery getCheckAppUserQuery)
        {
            var values = await Mediator.Send(getCheckAppUserQuery);
            if (values.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(values));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı.");
            }
        }
    }
}
