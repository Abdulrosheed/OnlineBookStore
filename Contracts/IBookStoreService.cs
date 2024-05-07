using OnlineBookstore.Dtos;

namespace OnlineBookstore.Contracts;
public interface IBookStoreService
{
    Task DeleteBooksAsync(IList<int> ids);
    Task<decimal> GetRevenueAsync(DateTime startDate, DateTime endDate);
    Task<List<string>> GetTopSellingAuthorsAsync();
    Task<List<BookDto>> GetAllAsync();

}