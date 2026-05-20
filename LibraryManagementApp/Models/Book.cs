namespace LibraryManagementApp.Models
{
    public class Book
    {
       public int BookId { get; set; }
        public string Title { get; set; } =null!;
        public string Author { get; set; } =null!;
        public int PublishedYear { get; set; } 
        public string ISBN {get;set;} = null!;
        public int AvailableCopies {get;set;}

    }
  
    
}