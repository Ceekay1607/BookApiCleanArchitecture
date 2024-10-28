using Domain.Entities;
using Application.DTOs.Requests.Book;

namespace Application.Interfaces;

public interface IBookRepository
{
    Task<Domain.Entities.Book> GetBookByIdAsync(int id);
    Task<List<Domain.Entities.Book>> GetAllBooksAsync();
    Task<int> CreateBookAsync(CreateBookRequest book);
    Task UpdateBookPriceAsync(int id, double newPrice);
    Task DeleteBookAsync(int id);
}
