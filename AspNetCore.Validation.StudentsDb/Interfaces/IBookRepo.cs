using System.Collections.Generic;
using System.Threading.Tasks;
using Validation.Models;


namespace AspNetCore.Validation.StudentsDb.Interfaces
{
    public interface IBookRepo
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task SaveNewBook(Book book);
        Task UpdateBook(Book book);
        Task<bool> IsBookExists(int id);
        Task DeleteBook(Book book);
    }
}
