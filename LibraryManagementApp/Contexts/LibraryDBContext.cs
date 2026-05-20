using Microsoft.EntityFrameworkCore;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.Contexts
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Book> books {get;set;}
        public DbSet<Member> members{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}