using AspNetCore.Validation.StudentsDb.Interfaces;
using Microsoft.EntityFrameworkCore;
using Validation.DbContexts;
using Validation.Models;

namespace AspNetCore.Validation.StudentsDb.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly MyDbContext _context;

        public BookRepo(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            var bookToFind = await _context.Books.FindAsync(id);
            if (bookToFind != null)
            {
                return bookToFind;
            }
            return new Book();
        }

        public async Task SaveNewBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsBookExists(int id)
        {
           
            return await _context.Books.AnyAsync(b => b.Id == id);
        }

        
        public async Task UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}