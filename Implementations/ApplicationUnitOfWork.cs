
using OnlineBookstore.Context;
using OnlineBookstore.Contracts;

namespace OnlineBookstore.Implementations
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private readonly ApplicationContext _context;

        public ApplicationUnitOfWork(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}