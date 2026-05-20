using LibraryManagementApp.Interfaces;
using LibraryManagementApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryManagementApp.Services
{
    public class BookService : IBookService
    {
        readonly IBookRepository<int,string,Book> _bookRepository;
        public BookService(IBookRepository<int,string,Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public void AddBook(Book book)
        {
            _bookRepository.CreateBook(book);
        }

        public List<Book>? GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public Book? GetBookByBookId(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<Book>? SearchBook(string title)
        {
            return _bookRepository.SearchBook(title);
        }

        public Book? UpdateBook(int id, Book book)
        {   
            
            return _bookRepository.UpdateBook(book);
        }
    }
}