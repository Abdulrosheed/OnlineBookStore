using Bogus;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Context;
using OnlineBookstore.Contracts;
using OnlineBookstore.Entities;

public static class DataSeeder
{

    public static void Seed(ModelBuilder modelBuilder)
    {
        var bookId = 1;

        var books = new Faker<Book>()
            .RuleFor(b => b.Id, f => bookId++)
            .RuleFor(b => b.Title, f => f.Commerce.ProductName())
            .RuleFor(b => b.Author, f => f.Name.FullName())
            .RuleFor(b => b.Price, f => f.Finance.Amount(10, 100));

        var sales = new Faker<Sale>()
            .RuleFor(s => s.Id, f => f.IndexFaker + 1)
            .RuleFor(s => s.BookId, f => f.Random.Number(1, bookId - 1))
            .RuleFor(s => s.SaleDate, f => f.Date.Past(1, DateTime.UtcNow))
            .RuleFor(s => s.Amount, f => f.Finance.Amount(10, 100));

        modelBuilder.Entity<Book>().HasData(books.Generate(20));
        modelBuilder.Entity<Sale>().HasData(sales.Generate(20));

    }
}
