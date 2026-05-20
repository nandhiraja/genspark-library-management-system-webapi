using LibraryManagementApp.Contexts;
using LibraryManagementApp.Interfaces;
using LibraryManagementApp.Models;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Repositories
{
    public class BookRepository : IBookRepository<int, string, Book>
    {

        private LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void CreateBook(Book book)
        {
            _context.books.Add(book);
            _context.SaveChanges();
        }

        public List<Book>? GetAllBooks()
        {
            return _context.books.ToList();
        }

        public Book? GetBookById(int id)
        {
            return _context.books.Find(id);
        }

        public List<Book>? SearchBook(string keywords)
        {
            string searchPattern = $"%{keywords}%";
           return _context.books.Where(b=>EF.Functions.ILike(b.Author,searchPattern)|| 
                                           EF.Functions.ILike(b.Title,searchPattern)).ToList();
        }

        public Book UpdateBook(Book updatedBook)
        {
            Book? book = GetBookById(updatedBook.BookId);
            if (book == null)
            {
                throw new Exception($"Book not available {updatedBook.BookId}");
            }
            book.Author= updatedBook.Author;
            book.Title = updatedBook.Title;
            book.PublishedYear = updatedBook.PublishedYear;
            book.AvailableCopies = updatedBook.AvailableCopies;
            _context.SaveChanges();
            return book;

        }
        public Book DeleteBook(Book deleteBook)
        {
            Book? book = GetBookById(deleteBook.BookId);
            if (book == null)
            {
                throw new Exception($"Book not available {deleteBook.BookId}");
            }
            _context.books.Remove(book);
            _context.SaveChanges();
            return book;
        }
        
    }


}