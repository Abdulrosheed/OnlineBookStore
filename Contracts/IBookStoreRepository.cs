using OnlineBookstore.Entities;

namespace OnlineBookstore.Contracts;
public interface IBookStoreRepository
{
    void DeleteBooksAsync(IList<Book> books);
    Task<decimal> GetRevenueAsync(DateTime startDate, DateTime endDate);
    Task<List<string>> GetTopSellingAuthorsAsync();
    Task<bool> ValidateIdsAsync(IList<int> ids);
    Task<IList<Book>> GetBooksAsync(IList<int> ids);
    Task<IList<Book>> CreateBooksAsync(IList<Book> books);
    Task<IList<Sale>> CreateSalesAsync(IList<Sale> sales);
    Task<IList<Book>> GetAllAsync();
}
