using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyIdentityApi.Api.Application.Commands.UserCommands;

namespace MyIdentityApi.Api.Controllers;

public class UserController(IMediator mediator) : MyIdentityApiController
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    
    [HttpPost("create-user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand body)
    {
        try
        {
            await _mediator.Send(body);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}