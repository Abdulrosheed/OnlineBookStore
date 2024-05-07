
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Context;
using OnlineBookstore.Contracts;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookStoreController(IBookStoreService bookStoreService, ApplicationContext context) : ControllerBase
    {
        private readonly IBookStoreService _bookStoreService = bookStoreService;
        private readonly ApplicationContext _context = context;

        [HttpDelete]
        public async Task<IActionResult> DeleteBooks([FromBody] List<int> bookIds)
        {
            await _bookStoreService.DeleteBooksAsync(bookIds);
            return Ok();
        }
        [HttpGet("get-revenue")]
        public async Task<IActionResult> GetRevenue(DateTime startDate, DateTime endDate)
        {
            return Ok(await _bookStoreService.GetRevenueAsync(startDate,endDate));
        }
        [HttpGet]
        public async Task<IActionResult> GetTopSellingAuthors()
        {
            return Ok(await _bookStoreService.GetTopSellingAuthorsAsync());
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookStoreService.GetAllAsync());
        }
        
        
    }
}