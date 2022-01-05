using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Services.Interface;

namespace BookStore.Services.Service
{
    public class BookService:IBookService
    {
        private readonly IMongoCollection<Book> _book;
        public BookService(IBookStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _book = database.GetCollection<Book>(settings.BooksCollectionName);

        }

        public async Task<List<Book>> Get()
        {
            return await  _book.Find(book => true).ToListAsync();
             
        }
        public async Task<string> AddBook(Book addrequest)
        {
            await _book.InsertOneAsync(addrequest);
            return "Added Successfully";
        }
        public async Task<string> UpdateBook(Book updaterequest)
        {
            
             await _book.ReplaceOneAsync(x=>x.Id==updaterequest.Id,updaterequest);
            return "Updated Successfully";


        }
        public async Task<string> DeleteBook(string id)
        {

            await _book.DeleteOneAsync(x => x.Id == id);
            return "Deleted Successfully";
        }

        public async Task<Book> GetById(string id) =>
           await _book.Find<Book>(book => book.Id == id).FirstOrDefaultAsync();

    }
}

