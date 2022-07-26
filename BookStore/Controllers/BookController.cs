using BookStore.Models;
using BookStore.Services.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("BookPolicy")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetBook")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Book>))]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookService.Get());
        }

        [HttpGet("GetBookById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        public async Task<IActionResult> GetBookById(string id)
        {
            return Ok(await _bookService.GetById(id));
        }

        [HttpPost("AddBook")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AddBook(Book addrequest)
        {
            return Ok(await _bookService.AddBook(addrequest));
        }

        [HttpPatch("UpdateBook")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> UpdateBook(Book updaterequest)
        {
            return Ok(await _bookService.UpdateBook(updaterequest));
        }

        [HttpDelete("DeleteBook")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> DeleteBook(string id)
        {
            return Ok(await _bookService.DeleteBook(id));
        }
    } 
}
