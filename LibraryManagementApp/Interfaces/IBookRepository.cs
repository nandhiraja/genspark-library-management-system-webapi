
namespace LibraryManagementApp.Interfaces
{
    public interface IBookRepository<K,S,T> where T : class
    {
        public void CreateBook(T t);
        public List<T>?  GetAllBooks();
        public T? GetBookById(K id);
        public T UpdateBook(T t);
        public T DeleteBook(T t);
        public List<T>? SearchBook(S keywords);
    }
}