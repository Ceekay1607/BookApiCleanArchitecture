using Application.Book.Commands;
using Application.Book.Queries;
using Application.DTOs.Requests.Book;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        var query = new GetAllBooksQuery();
        var books = await _mediator.Send(query);
        return Ok(books);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var query = new GetBookByIdQuery(id);
        try
        {
            var bookResponse = await _mediator.Send(query);
            return Ok(bookResponse);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddAsync([FromBody] CreateBookRequest request)
    {
        var command = new CreateBookCommand
        {
            Title = request.Title,
            Author = request.Author,
            Price = request.Price
        };

        var bookId = await _mediator.Send(command);

        return Ok(bookId);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateBookPrice(int id, [FromBody] double newPrice)
    {
        try
        {
            var command = new UpdateBookPriceCommand(id, newPrice);
            var result = await _mediator.Send(command);

            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ArgumentException e)
        {

            return BadRequest(e.Message);
        }

    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            var command = new DeleteBookCommand(id);
            var result = await _mediator.Send(command);
            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
