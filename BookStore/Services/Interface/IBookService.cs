using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services.Interface
{
    public interface IBookService
    {
        Task<List<Book>> Get();
        Task<string> AddBook(Book addrequest);
        Task<string> UpdateBook(Book updaterequest);
        Task<string> DeleteBook(string id);
        Task<Book> GetById(string id);
    }
}
