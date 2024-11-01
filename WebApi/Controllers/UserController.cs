using Application.DTOs.Requests.User;
using Application.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddUser([FromBody] RegisterRequest registerRequest, CancellationToken cancellationToken) {
        Task.Delay(5000, cancellationToken);
        var command = new CreateUserCommand{Username = registerRequest.Username, Password = registerRequest.Password, Admin = registerRequest.Admin};
        var userId = await _mediator.Send(command, cancellationToken);
        return NoContent();
    }
}
