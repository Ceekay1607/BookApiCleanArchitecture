using Application.DTOs.Requests.User;
using Application.Interfaces;
using Application.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest) {
        try {
            var command = new LoginCommand {Username = loginRequest.Username, Password = loginRequest.Password};
            var response = await _mediator.Send(command);
            return Ok(response);

        } catch (UnauthorizedAccessException e) {
            return Unauthorized(e.Message);
        }
    }
}
