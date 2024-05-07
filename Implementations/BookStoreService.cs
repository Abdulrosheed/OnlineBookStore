

using OnlineBookstore.Context;
using OnlineBookstore.Contracts;
using OnlineBookstore.Dtos;
using OnlineBookstore.Exceptions;

namespace OnlineBookstore.Implementations;

public class BookStoreService(IBookStoreRepository bookStoreRepository, IApplicationUnitOfWork applicationUnitOfWork, ILogger<BookStoreService> logger) : IBookStoreService
{
    private readonly IBookStoreRepository _bookStoreRepository = bookStoreRepository;
    private readonly ILogger<BookStoreService> _logger = logger;
    private readonly IApplicationUnitOfWork _applicationUnitOfWork = applicationUnitOfWork;

    public async Task DeleteBooksAsync(IList<int> ids)
    {
        var idsIsValid = await _bookStoreRepository.ValidateIdsAsync(ids);
        if(!idsIsValid)
        {
            _logger.LogError("Invalid ids", ids);
            throw new DomainException($"Invalid ids", 400);
        }
        var books = await _bookStoreRepository.GetBooksAsync(ids);
        _bookStoreRepository.DeleteBooksAsync(books);
       await _applicationUnitOfWork.SaveChangesAsync();
    }

    public async Task<List<BookDto>> GetAllAsync()
    {
        var books = await _bookStoreRepository.GetAllAsync();
        return books.Select(a => new BookDto {Id = a.Id, Author = a.Author, Price = a.Price, Title = a.Title}).ToList();
    }

    public async Task<decimal> GetRevenueAsync(DateTime startDate, DateTime endDate)
    {
        return await _bookStoreRepository.GetRevenueAsync(startDate.ToUniversalTime(), endDate.ToUniversalTime());
    }

    public async Task<List<string>> GetTopSellingAuthorsAsync()
    {
        return await _bookStoreRepository.GetTopSellingAuthorsAsync();
    }
}
