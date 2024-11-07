using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Application.Dtos.UsersManage;
using TaskManagerAPI.Application.UsersManage.LoginUser.Commands;
using TaskManagerAPI.Application.UsersManage.RegisterUser.Commands;

namespace TaskManagerAPI.WebAPI.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : BaseController
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
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

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserDto loginUserDto)
    {
        var command = new LoginUserCommand
        {
            LoginUserDto = loginUserDto
        };

        var token = await Mediator.Send(command);
        return Ok(new { Token = token });
    }
}
