using System.Linq.Expressions;
using LibraryManagementApp.Interfaces;
using LibraryManagementApp.Models;
using LibraryManagementApp.Models.DTOs;
using LibraryManagementApp.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController: ControllerBase
    {
        private IBookService _booksService;
        public BookController(IBookService bookService)
        {
               _booksService = bookService;
        }
        static List<Book>BookList = new List<Book>();

        [HttpGet("all")]
        public ActionResult<List<GetBookResponse>> GetAllBooks()
        {
            try
            {
                List<Book>? allBooks = _booksService.GetAllBooks();
                if(allBooks==null)
                    return Ok(new List<GetBookResponse>());
                else
                {
                    List<GetBookResponse> allbooksResponse = new List<GetBookResponse>();
                    foreach(var book in allBooks)
                    {
                        allbooksResponse.Add(new GetBookResponse()
                        {
                            BookId= book.BookId,
                            Title = book.Title,
                            Author = book.Author,
                            PublishedYear = book.PublishedYear,
                            ISBN = book.ISBN,
                            AvailableCopies = book.AvailableCopies
                        });

                    }
                    return Ok(allbooksResponse);
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to get all Books now\n{ex}");
            }
        }

         [HttpGet("search")]
        public ActionResult<List<GetBookResponse>> SearchBook(string title)
        {
            try
            {
                List<Book>? allBooks = _booksService.SearchBook(title);
                if(allBooks==null)
                    return Ok(new List<GetBookResponse>());
                else
                {
                    List<GetBookResponse> allbooksResponse = new List<GetBookResponse>();
                    foreach(var book in allBooks)
                    {
                        allbooksResponse.Add(new GetBookResponse()
                        {
                            BookId= book.BookId,
                            Title = book.Title,
                            Author = book.Author,
                            PublishedYear = book.PublishedYear,
                            ISBN = book.ISBN,
                            AvailableCopies = book.AvailableCopies
                        });

                    }
                    return Ok(allbooksResponse);
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to get search result Books now\n{ex}");
            }
        }

        [HttpGet]
        public ActionResult<GetBookResponse> GeBooksById(int id)
        {   
            try
            {
                Book? book = _booksService.GetBookByBookId(id);
                if(book==null)
                    return Ok(new List<GetBookResponse>());
                else
                {
                    GetBookResponse booksResponse =new GetBookResponse()
                        {
                            BookId= book.BookId,
                            Title = book.Title,
                            Author = book.Author,
                            PublishedYear = book.PublishedYear,
                            ISBN = book.ISBN,
                            AvailableCopies = book.AvailableCopies
                        };

                    
                    return Ok(booksResponse);
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to get all Books now\n{ex}");
            }
        }

        [HttpPost]
        public ActionResult<string> CreateBook(CreateBookRequest book)
        {   
            try{
                Book newbook = new Book()
                {
                    Title = book.Title,
                    Author = book.Author,
                    PublishedYear = book.PublishedYear,
                    ISBN = book.ISBN,
                    AvailableCopies = book.AvailableCopies
                };
                _booksService.AddBook(newbook);
                 return Ok("Book Successfully Added");
            }
             catch(Exception ex)
            {
                return BadRequest($"Unable to create new book \n{ex}");
            }
        }
    }
}