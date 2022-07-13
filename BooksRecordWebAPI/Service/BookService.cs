using BooksRecordWebAPI.Configuration;
using BooksRecordWebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BooksRecordWebAPI.Service
{
    public class BookService: IBookService
    {
        private readonly IMongoCollection<Books> _book;
        private readonly BooksConfiguration _settings;

        public BookService(IOptions<BooksConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _book = database.GetCollection<Books>(_settings.BooksCollectionName);
        }
        public async Task<List<Books>> GetAllAsync()
        {
            return await _book.Find(c => true).ToListAsync();
        }
        public async Task<Books> GetByIdAsync(string id)
        {
            return await _book.Find<Books>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Books> CreateAsync(Books book)
        {
            await _book.InsertOneAsync(book);
            return book;
        }
        public async Task UpdateAsync(string id, Books book)
        {
            await _book.ReplaceOneAsync(c => c.Id == id, book);
        }
        public async Task DeleteAsync(string id)
        {
            await _book.DeleteOneAsync(c => c.Id == id);
        }
    }
}
