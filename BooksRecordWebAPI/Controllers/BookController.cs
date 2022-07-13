using BooksRecordWebAPI.Models;
using BooksRecordWebAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BooksRecordWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Books book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _bookService.CreateAsync(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id}, book);

           // return Ok(book.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Books booksData)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.UpdateAsync(id, booksData);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.DeleteAsync(book.Id);
            return NoContent();
        }
    }
}
