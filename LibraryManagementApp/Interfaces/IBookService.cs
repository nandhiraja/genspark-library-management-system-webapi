using LibraryManagementApp.Models;

namespace LibraryManagementApp.Interfaces
{
    public interface IBookService
    {
        public void AddBook(Book book);
        public Book? GetBookByBookId(int id);
        public List<Book>? SearchBook(string title);
        public List<Book>? GetAllBooks();
        public Book? UpdateBook(int id , Book book);

    }
}