

namespace OnlineBookstore.Contracts
{
    public interface IApplicationUnitOfWork
    {
        Task<int> SaveChangesAsync();

    }
}