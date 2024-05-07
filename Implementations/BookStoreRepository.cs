
using OnlineBookstore.Context;
using OnlineBookstore.Contracts;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Entities;
namespace OnlineBookstore.Implementations;

public class BookStoreRepository(ApplicationContext context) : IBookStoreRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<IList<Book>> CreateBooksAsync(IList<Book> books)
    {
        await _context.Books.AddRangeAsync(books);
        return books;
    }

    public async Task<IList<Sale>> CreateSalesAsync(IList<Sale> sales)
    {
        await _context.Sales.AddRangeAsync(sales);
        return sales;
    }

    public void DeleteBooksAsync(IList<Book> books)
    {
        _context.Books.RemoveRange(books);
    }

    public async Task<IList<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<IList<Book>> GetBooksAsync(IList<int> ids)
    {
        return await _context.Books.Where(a => ids.Contains(a.Id)).ToListAsync();
    }

    public async Task<decimal> GetRevenueAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Sales
            .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
            .SumAsync(s => s.Amount);
    }

    public async Task<List<string>> GetTopSellingAuthorsAsync()
    {
        return await _context.Sales
        .GroupBy(s => s.Book.Author)
        .Select(g => new
        {
            Author = g.Key,
            TotalSales = g.Sum(s => s.Amount)
        })
        .OrderByDescending(a => a.TotalSales)
        .Take(10)
        .Select(a => a.Author)
        .ToListAsync();
    }

    public async Task<bool> ValidateIdsAsync(IList<int> ids)
    {
        var uniqueIds = ids.Distinct().ToList();
        var matchingCount = await context.Books.CountAsync(b => uniqueIds.Contains(b.Id));
        return matchingCount == uniqueIds.Count;
    }
}
