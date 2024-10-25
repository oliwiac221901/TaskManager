using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Dtos.UsersManage;
using TaskManagerAPI.Application.UsersManage.RegisterUser.Commands;

namespace TaskManagerAPI.WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class UserController : BaseController
    {
        [HttpPost("register")]
        [ProducesResponseType(typeof(int),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            var command = new RegisterUserCommand
            {
                RegisterUserDto = registerUserDto
            };

            var result = await Mediator.Send(command);
            return Created(string.Empty, result);
        }
    }
}
