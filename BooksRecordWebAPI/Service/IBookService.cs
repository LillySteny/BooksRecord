using BooksRecordWebAPI.Models;

namespace BooksRecordWebAPI.Service
{
    public interface IBookService
    {
        Task<List<Books>> GetAllAsync();
        Task<Books> GetByIdAsync(string id);
        Task<Books> CreateAsync(Books book);
        Task UpdateAsync(string id, Books book);
        Task DeleteAsync(string id);
    }
}
