using AspNetCore.Validation.StudentsDb.Interfaces;
using Validation.Models;

namespace AspNetCore.Validation.StudentsDb.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepo _repository;

        public BookService(IBookRepo repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _repository.GetAllBooks();
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await _repository.GetBookById(id);
        }

        public async Task AddBook(Book book)
        {
            await _repository.SaveNewBook(book); 
        }

        public async Task UpdateBook(Book book)
        {
            await _repository.UpdateBook(book); 
        }

        public async Task DeleteBook(int id)
        {
            var book = await _repository.GetBookById(id);
            if (book != null)
            {
                await _repository.DeleteBook(book);
            }
        }

        public async Task<bool> BookExists(int id)
        {
            return await _repository.IsBookExists(id);
        }
    }
}
