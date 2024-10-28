using Application.DTOs.Requests.Book;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    private Book ConvertToBookFromBookRequest(CreateBookRequest createBookRequest)
    {
        return new Book { Title = createBookRequest.Title, Author = createBookRequest.Author, Price = createBookRequest.Price };
    }

    public async Task<int> CreateBookAsync(CreateBookRequest createBookRequest)
    {
        Book book = ConvertToBookFromBookRequest(createBookRequest);
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book.Id;
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await GetBookByIdAsync(id);
        if (book == null)
        {
            throw new KeyNotFoundException($"Book with id {id} not found.");
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public Task<List<Book>> GetAllBooksAsync()
    {
        return _context.Books.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book == null)
        {
            throw new KeyNotFoundException($"Book with id {id} not found.");
        }
        return book;
    }

    public async Task UpdateBookPriceAsync(int id, double newPrice)
    {
        var book = await GetBookByIdAsync(id);
        if (book == null)
        {
            throw new KeyNotFoundException($"Book with id {id} not found.");
        }

        if (newPrice < 0)
        {
            throw new ArgumentException("Price must be a positive number.");
        }

        book.Price = newPrice;
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }
}
